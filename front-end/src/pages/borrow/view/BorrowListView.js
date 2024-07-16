import React, {Suspense, useEffect, useRef} from 'react';
import {Button, message, Spin, Tooltip} from 'antd';
import {useRequest} from "../../../custom-hook/useRequest";
import CheckOutCreateForm from "../form/CheckOutCreateForm";
import CommonGrid from "../../../common/core/grid/CommonGrid";
import CheckOutUpdateForm from "../form/CheckOutUpdateForm";
import {
  CHECK_OUT_CREATE_API,
  CHECK_OUT_DELETE_API,
  CHECK_OUT_INDEX_API,
  CHECK_OUT_SHOW_API,
  CHECK_OUT_UPDATE_API
} from "../api/BorrowApi";
import {checkOutColDef} from "../config/checkOutColDef";
import {BOOK_COMBO_OPTION_CAN_BORROW_API} from "../../book/api/BookApi";
import {MEMBER_COMBO_OPTION_CAN_BORROW_API} from "../../member/api/MemberApi";
import useMergeState from "../../../custom-hook/useMergeState";
import {DeleteOutlined, EditOutlined, FormOutlined, InfoCircleOutlined} from "@ant-design/icons";
import Loading from "../../../component/Loading";
import _ from "lodash";
import Alert from "../../../common/Alert/Alert";

const BorrowListView = () => {
  const {get, deleteApi} = useRequest();
  const refGrid = useRef(null);

  const [state, setState] = useMergeState({
    rowData: [],
    loading: true,
  });

  const apiCreate = CHECK_OUT_CREATE_API;
  const apiDetail = CHECK_OUT_SHOW_API;
  const apiUpdate = CHECK_OUT_UPDATE_API;
  const apiDelete = CHECK_OUT_DELETE_API;


  const defaultColDef = {};

  useEffect(() => {
    fetchData();
  }, []);

  const fetchData = async () => {
    try {
      const response = await get(CHECK_OUT_INDEX_API);
      if (response?.success) {
        const value = response?.data;
        setState({
          rowData: value
        });
      } else {
        // ToastUtil.ToastApiError(response?.message);
      }
    } catch (error) {
      console.error('Error fetching data:', error);
      // ToastUtil.ToastServerError(error.message);
    } finally {
      setState({
        loading: false
      });
    }
  };

  const reloadData = async () => {
    try {
      const response = await get(CHECK_OUT_INDEX_API);
      if (response?.success) {
        refGrid.current.setRowData(response.data);
      } else {
        // ToastUtil.ToastApiError(response?.message);
      }
    } catch (error) {
      console.error('Error fetching data:', error);
      // ToastUtil.ToastServerError(error.message);
    } finally {
      setState({
        loading: false
      });
    }
  }

  const handleEdit = (data) => {
    const FormUpdate = CheckOutUpdateForm;
    refGrid.current?.modalRef.onOpen(
      <Suspense fallback={<Loading style={{height: 300}} open={true}/>}>
        <FormUpdate
          reloadData={reloadData}
          id={_.get(data, 'id')}
          apiSave={apiUpdate}
          apiDetail={apiDetail}
          onClose={() => {
            refGrid.current?.modalRef.onClose();
          }}
        />
      </Suspense>,
      renderTitleForm('Chỉnh sửa'),
      '850px'
    );
  };

  const handleDelete = async (data) => {
    try {
      const confirm = await Alert.Swal_confirm(
        "Thông báo",
        "Bạn có chắc muốn xoá dữ liệu này không?",
      )
      if (confirm === true) {
        const response = await deleteApi(`${apiDelete}?id=${data.id}`);
        if (response?.success) {
          await reloadData();
          message.success('Xoá thành công');
        }
      }

    } catch (error) {
      message.error('Xoá thất bại');
    }
  };

  // const handleDetail = (data) => {
  //   const FormDetail = props.formCRUD?.detailForm;
  //   refGrid.current?.modalRef.onOpen(
  //     <Suspense fallback={<Loading style={{height: 300}} open={true}/>}>
  //       <FormDetail
  //         apiDetail={apiDetail}
  //         id={data?.id}
  //         onClose={() => {
  //           refGrid.current?.modalRef.onClose();
  //         }}
  //         {...props.formCRUD?.propsForm}
  //       />
  //     </Suspense>,
  //     renderTitleForm('Chi tiết'),
  //     '850px'
  //   );
  // };

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
                <FormOutlined/>
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

  const renderAction = (params) => {
    const isReturned = _.get(params, 'data.isReturned');
    return !isReturned && <div className={"flex justify-center items-center gap-2 h-full"}>
      {/*{props.buttonCRUD?.hasDetail &&*/}
      {/*  <Tooltip title="Chi tiết"><Button onClick={() => handleDetail(params.data)} icon={<InfoCircleOutlined/>}*/}
      {/*                                    className={'btn-detail'}/></Tooltip>}*/}

      <Tooltip title="Chỉnh sửa"><Button onClick={() => handleEdit(params.data)} icon={<EditOutlined/>}
                                         className={'btn-update'}/></Tooltip>

      <Tooltip title="Xoá"><Button onClick={() => handleDelete(params.data)} icon={<DeleteOutlined/>}
                                   className={'btn-delete'}/></Tooltip>
    </div>
  }

  if (state.loading) {
    return (
      <div className="ag-theme-alpine"
           style={{height: '100%', width: '100%', display: 'flex', justifyContent: 'center', alignItems: 'center'}}>
        <Spin size="large"/>
      </div>
    );
  }

  return (
    <div className="ag-theme-alpine">
      <CommonGrid
        ref={refGrid}
        columnDefs={checkOutColDef}
        defaultColDef={defaultColDef}
        rowData={state.rowData}
        isGridDefault={true}
        reloadData={() => reloadData()}
        renderAction={renderAction}
        formCRUD={{
          createForm: CheckOutCreateForm,
          updateForm: CheckOutUpdateForm,
        }}
        buttonCRUD={{
          hasCreate: true,
          hasDelete: true,
          hasUpdate: true,
          // hasDetail: true,
          // onCreate: onCreate,
          // onDetailRow: onDetailRow,
          // onEditRow: onEditRow,
          apiCreate: CHECK_OUT_CREATE_API,
          apiDetail: CHECK_OUT_SHOW_API,
          apiUpdate: CHECK_OUT_UPDATE_API,
          apiDelete: CHECK_OUT_DELETE_API
        }}
      />
    </div>
  );
};

export default BorrowListView;
