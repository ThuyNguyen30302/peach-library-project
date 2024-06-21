import React, { forwardRef, useImperativeHandle, useRef, Suspense } from 'react';
import { AgGridReact } from 'ag-grid-react';
import 'ag-grid-community/styles/ag-grid.css';
import 'ag-grid-community/styles/ag-theme-alpine.css';
import { Button, Tooltip, Spin, message } from 'antd';
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

const CommonGrid = forwardRef((props, ref) => {
  const { rights } = useSelector((stateRedux) => ({
    rights: stateRedux?.root?.get('rights'),
  }));

  const {deleteApi} = useRequest();
  const gridRef = useRef(null);
  const modalRef = useRef(null);

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
    const FormUpdate = props.formCRUD?.updateForm;
    console.log(props.buttonCRUD?.apiUpdate)
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
    // Modal.confirm({
    //   title: 'Chỉnh sửa',
    //   content: <Suspense fallback={<Spin />}>
    //     <FormEdit onClose={handleCloseModal} rowData={data} />
    //   </Suspense>,
    //   width: props.formCRUD?.popUpWidth || 850,
    // });
  };

  const handleDelete = async (data) => {
    try {
      const response = await deleteApi(`${props.buttonCRUD?.apiDelete}?id=${data.id}`);
      if (response?.success) {
        message.success('Deleted successfully');
        props.reloadData && await props.reloadData();
      }
    } catch (error) {
      message.error('Failed to delete');
    }
  };

  const handleDetail = (data) => {
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
    // Modal.confirm({
    //   title: 'Chi tiết',
    //   content: <Suspense fallback={<Spin />}>
    //     <FormDetail rowData={data} />
    //   </Suspense>,
    //   width: props.formCRUD?.popUpWidth || 850,
    // });
  };

  const actionColumnDefs = {
    headerName: 'Actions',
    width: 120,
    maxWidth: 120,
    cellRenderer: (params) => (
      <div className={"flex justify-around items-center h-full"}>
        {/*{props.buttonCRUD?.hasDetail && <Tooltip title="Detail"><Button onClick={() => handleDetail(params.data)} icon={<InfoCircleOutlined />} /></Tooltip>}*/}
        {/*{props.buttonCRUD?.hasUpdate && <Tooltip title="Edit"><Button onClick={() => handleEdit(params.data)} icon={<EditOutlined />} /></Tooltip>}*/}
        {/*{props.buttonCRUD?.hasDelete && <Tooltip title="Delete"><Button onClick={() => handleDelete(params.data)} icon={<DeleteOutlined />} /></Tooltip>}*/}
        {props.buttonCRUD?.hasDetail && <Tooltip title="Detail"><Button onClick={() => handleDetail(params.data)} icon={<InfoCircleOutlined />} /></Tooltip>}
        {props.buttonCRUD?.hasUpdate && checkPermission(props.rightConfig?.updateRight) && <Tooltip title="Edit"><Button onClick={() => handleEdit(params.data)} icon={<EditOutlined />} /></Tooltip>}
        {props.buttonCRUD?.hasDelete && checkPermission(props.rightConfig?.deleteRight) && <Tooltip title="Delete"><Button onClick={() => handleDelete(params.data)} icon={<DeleteOutlined />} /></Tooltip>}
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
          marginBottom: 10,
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
      {props.buttonCRUD?.hasCreate && <Tooltip title="Create"><Button onClick={() => {handleCreate()}} icon={<PlusOutlined />} /></Tooltip>}
    </div>;
  }

  const renderLeftActionToolBar = () => {
    return <div>
      {/*{props.buttonCRUD?.hasCreate && <Tooltip title="Create"><Button onClick={() => {handleCreate()}} icon={<PlusOutlined />} /></Tooltip>}*/}
    </div>;
  }

  return (
    <div className="ag-theme-alpine" style={{ height: '100%', width: '100%' }}>
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
          columnDefs={[...props.columnDefs, actionColumnDefs]}
          defaultColDef={{
            resizable: true,
            sortable: false,
            filter: false,
            autoSizeStrategy: {
              type: 'fitGridWidth',
              defaultMinWidth: 100,
            },
            ...props.defaultColDef,
          }}
          pagination={true}
          paginationPageSizeSelector={[10,20,50,100]}
          paginationPageSize ={10}
          onGridReady={(event) => event.api.sizeColumnsToFit()}
        />
      </div>
      <BaseModal ref={modalRef} />
    </div>
  );
});

CommonGrid.displayName = 'CommonGrid';
export default CommonGrid;
