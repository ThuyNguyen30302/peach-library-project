import React, {Suspense, useEffect, useRef} from 'react';
import CommonGrid from "../../../common/core/grid/CommonGrid";
import {bookDetailColDel} from "../../book/config/bookDetailColDef";
import useMergeState from "../../../custom-hook/useMergeState";
import {useRequest} from "../../../custom-hook/useRequest";
import {BOOK_lIST_DETAIL_API} from "../../book/api/BookApi";
import {Button, Spin, Tooltip} from "antd";
import {historyBookColDef} from "../config/historyBookColDef";
import UpdateRequestBorrowForm from "./UpdateRequestBorrowForm";
import {AUTHOR_UPDATE_API} from "../../author/api/AuthorApi";
import {CHECK_OUT_SHOW_API, CHECK_OUT_UPDATE_API} from "../../borrow/api/BorrowApi";
import _ from "lodash";
import {DeleteOutlined, EditOutlined, FormOutlined} from "@ant-design/icons";
import CheckOutUpdateForm from "../../borrow/form/CheckOutUpdateForm";
import Loading from "../../../component/Loading";

const HistoryBorrowForm = (props) => {
  const formRef = useRef(null);
  const [state, setState] = useMergeState({
    rowData: [],
    loading: true,
  });
  const { get } = useRequest();
  const refGrid = useRef(null);

  const apiDetail = CHECK_OUT_SHOW_API;
  const apiUpdate = CHECK_OUT_UPDATE_API;

  useEffect(() => {
    fetchData();
  }, []);

  const fetchData = async () => {
    try {
      const response = await get(props.api + '/' + props.memberId);
      if (response?.success) {
        setState({
          rowData: response?.data
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
      const response = await get(props.api + '/' + props.memberId);
      if (response?.success) {
        setState({
          rowData: response?.data
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

  const handleEdit = (data) => {
    const FormUpdate = UpdateRequestBorrowForm;
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
    </div>
  }

  if (state.loading) {
    return (
      <div className="ag-theme-alpine" style={{ height: '100%', width: '100%', display: 'flex', justifyContent: 'center', alignItems: 'center' }}>
        <Spin size="large" />
      </div>
    );
  }

  return (
    <div className="ag-theme-alpine">
      <CommonGrid
        ref={refGrid}
        columnDefs={historyBookColDef}
        rowData={state.rowData}
        formCRUD={{
          updateForm: UpdateRequestBorrowForm,
        }}
        renderAction={renderAction}
        buttonCRUD={{
          hasUpdate: true,
          apiDetail: apiDetail,
          apiUpdate: apiUpdate,
        }}
      />
    </div>
  );
};

export default HistoryBorrowForm;