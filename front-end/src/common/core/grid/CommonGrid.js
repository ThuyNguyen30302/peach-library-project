import React, {forwardRef, useImperativeHandle, useRef, Suspense, useMemo} from 'react';
import { AgGridReact } from 'ag-grid-react';
import 'ag-grid-community/styles/ag-grid.css';
import 'ag-grid-community/styles/ag-theme-alpine.css';
import { Button, Tooltip, message } from 'antd';
import {
  PlusOutlined,
  DeleteOutlined,
  EditOutlined,
  InfoCircleOutlined,
  FormOutlined
} from '@ant-design/icons';
import { useSelector } from 'react-redux';
import _ from 'lodash';
import {useRequest} from "../../../custom-hook/useRequest";
import Loading from "../../../component/Loading";
import BaseModal from "../Modal/BaseModal";
import Overlay from "../../../component/Overlay";

const CommonGrid = forwardRef((props, ref) => {
  const { rights } = useSelector((stateRedux) => ({
    rights: stateRedux?.root?.get('rights'),
  }));

  const {deleteApi} = useRequest();
  const gridRef = useRef(null);
  const modalRef = useRef(null);
  const actionRow = props.actionRow??true;
  const numberRow = props.numberRow??true;

  useImperativeHandle(ref, () => ({
    setRowData: (data) => {
      gridRef.current.api.setRowData(data);
    },
    getGridRef: () => gridRef?.current,
  }));

  const checkPermission = (requiredPermissions) => {
    if (!requiredPermissions) return true;
    return _.intersection(rights, requiredPermissions).length > 0;
  };

  const handleCreate = () => {
    if (props.buttonCRUD.onCreate) {
      props.buttonCRUD.onCreate();
      return;
    }
    const FormCreate = props.formCRUD?.createForm;
    modalRef.current?.onOpen(
      <Suspense fallback={<Loading style={{ height: 300 }} open={true} />}>
        <FormCreate
          reloadData={props.reloadData}
          apiSave={props.buttonCRUD?.apiCreate}
          onClose={() => {
            modalRef.current?.onClose();
          }}
        />
      </Suspense>,
      renderTitleForm('Tạo mới'),
      props.formCRUD?.popUpWidth || '850px'
    );
  };

  const handleEdit = (data) => {
    if (props.buttonCRUD.onEditRow) {
      props.buttonCRUD.onEditRow();
      return;
    }
    const FormUpdate = props.formCRUD?.updateForm;
    modalRef.current?.onOpen(
      <Suspense fallback={<Loading style={{ height: 300 }} open={true} />}>
        <FormUpdate
          reloadData={props.reloadData}
          id={_.get(data, 'id')}
          apiSave={props.buttonCRUD?.apiUpdate}
          apiDetail={props.buttonCRUD?.apiDetail}
          onClose={() => {
            modalRef.current?.onClose();
          }}
        />
      </Suspense>,
      renderTitleForm('Chỉnh sửa'),
      props.formCRUD?.popUpWidth || '850px'
    );
  };

  const handleDelete = async (data) => {
    try {
      const response = await deleteApi(`${props.buttonCRUD?.apiDelete}?id=${data.id}`);
      if (response?.success) {
        props.reloadData && await props.reloadData();
        message.success('Xoá thành công');
      }
    } catch (error) {
      message.error('Xoá thất bại');
    }
  };

  const handleDetail = (data) => {
    if (props.buttonCRUD.onDetailRow) {
      props.buttonCRUD.onDetailRow(data);
      return;
    }
    const FormDetail = props.formCRUD?.detailForm;
    modalRef.current?.onOpen(
      <Suspense fallback={<Loading style={{ height: 300 }} open={true} />}>
        <FormDetail
          apiDetail={props.buttonCRUD?.apiDetail}
          id={data?.id}
          onClose={() => {
            modalRef.current?.onClose();
          }}
        />
      </Suspense>,
      renderTitleForm('Chi tiết'),
      props.formCRUD?.popUpWidth || '850px'
    );
  };

  const numberColumnDefs = {
    headerName: 'STT',
    width: 70,
    maxWidth: 70,
    minWidth: 70,
    valueGetter: 'node.rowIndex + 1',
    cellStyle: { textAlign: 'center' }
  }

  const actionColumnDefs = {
    headerName: 'Hành động',
    width: 150,
    maxWidth: 150,
    minWidth: 150,
    pinned: 'right',
    cellRenderer: (params) => (
      <div className={"flex justify-center items-center gap-2 h-full"}>
        {props.buttonCRUD?.hasDetail && <Tooltip title="Detail"><Button onClick={() => handleDetail(params.data)} icon={<InfoCircleOutlined />} className={'btn-detail'} /></Tooltip>}
        {props.buttonCRUD?.hasUpdate && checkPermission(props.rightConfig?.updateRight) && <Tooltip title="Edit"><Button onClick={() => handleEdit(params.data)} icon={<EditOutlined />} className={'btn-update'} /></Tooltip>}
        {props.buttonCRUD?.hasDelete && checkPermission(props.rightConfig?.deleteRight) && <Tooltip title="Delete"><Button onClick={() => handleDelete(params.data)} icon={<DeleteOutlined />} className={'btn-delete'} /></Tooltip>}
      </div>
    ),
  };

  const renderTitleForm = (text) => {
    return (
      <span
        style={{
          position: 'relative',
          display: 'flex',
          alignItems: 'center',
          marginBottom: 20,
          marginRight: 7,
        }}>
                <FormOutlined />
                <span
                  style={{
                    fontSize: 15,
                    display: 'flex',
                    marginLeft: 10
                  }}>
                    {text}
                </span>
            </span>
    );
  };

  const renderRightActionToolBar = () => {
    return <div>
      {props.buttonCRUD?.hasCreate && <Tooltip title="Create"><Button onClick={() => {handleCreate()}} icon={<PlusOutlined />} className={'btn-create'} /></Tooltip>}
    </div>;
  }

  const renderLeftActionToolBar = () => {
    return <div>
      {/*{props.buttonCRUD?.hasCreate && <Tooltip title="Create"><Button onClick={() => {handleCreate()}} icon={<PlusOutlined />} /></Tooltip>}*/}
    </div>;
  }

  const colDefs = useMemo(() => {
    const colDefs = [];
    if (numberRow) {
      colDefs.push(numberColumnDefs);
    }
    colDefs.push(...props.columnDefs);
    if (actionRow) {
      colDefs.push(actionColumnDefs);
    }
    return colDefs;
  }, [numberRow, props.columnDefs, actionRow]);


  return (
    <div className="common-grid" style={{ height: '100%', width: '100%' }}>
      <div className="flex justify-between mb-3">
        <div>
          {renderLeftActionToolBar()}
        </div>
        <div>
          {renderRightActionToolBar()}
        </div>
      </div>
      <div>
        <AgGridReact
          ref={gridRef}
          {...props}
          columnDefs={colDefs}
          defaultColDef={{
            resizable: true,
            sortable: false,
            filter: false,
            autoSizeStrategy: {
              type: 'fitGridWidth',
              defaultMinWidth: 100,
            },
            flex: 1,
            ...props.defaultColDef,
          }}
          pagination={true}
          paginationPageSizeSelector={[10,20,50,100]}
          paginationPageSize ={10}
          noRowsOverlayComponent={Overlay}
          tooltipShowDelay={500}
          onGridReady={(event) => {
            event.api.sizeColumnsToFit();
          }}
        />
      </div>
      <BaseModal ref={modalRef} />
    </div>
  );
});

CommonGrid.displayName = 'CommonGrid';
export default CommonGrid;
