import React, {Suspense, useCallback, useEffect, useRef} from 'react';
import {useRequest} from "../../custom-hook/useRequest";
import useMergeState from "../../custom-hook/useMergeState";
import "./homeStyle.scss";
import {
  BORROWED_BOOK_FOR_MEMBER_INDEX_API,
  CHECK_OUT_BY_MEMBER_INDEX_API, CHECK_OUT_CREATE_API
} from "../borrow/api/BorrowApi";
import CommonGrid from "../../common/core/grid/CommonGrid";
import {Button, Form, Input, Spin, Tooltip} from "antd";
import _ from "lodash";
import {FormOutlined, PlusOutlined, UnorderedListOutlined} from "@ant-design/icons";
import Loading from "../../component/Loading";
import CreateRequestBorrowForm from "./form/CreateRequestBorrowForm";
import BaseModal from "../../common/core/Modal/BaseModal";
import {useSelector} from "react-redux";
import Alert from "../../common/Alert/Alert";
import HistoryBorrowForm from "./form/HistoryBorrowForm";
import {bookMemberViewColDef} from "./config/bookMemberViewColDef";

const {Search} = Input;

const MemberHome = () => {
  const {get, checkLogin} = useRequest();
  const [state, setState] = useMergeState({
    rowData: [],
    filter: {
      bookTitle: ''
    },
    loading: true,
  });
  const authData = useSelector(state => state.root.get('authData'));
  const refGrid = useRef(null);
  const [form] = Form.useForm();
  const modalRef = useRef(null);

  const apiCreate = CHECK_OUT_CREATE_API;
  const apiHistoryBorrow = CHECK_OUT_BY_MEMBER_INDEX_API;

  useEffect(() => {
    fetchData();
  }, [state.filter]);

  const fetchData = async () => {
    Promise.all([
      checkLogin(),
      get(BORROWED_BOOK_FOR_MEMBER_INDEX_API, {
        params: {
          key: state.filter.bookTitle
        }
      }),
    ]).then(([resCheckLogin, resBorrowedBook]) => {
      if (resBorrowedBook?.success) {
        const responseBorrowedBook = resBorrowedBook?.data;

        if (responseBorrowedBook) {
          setState({
            rowData: responseBorrowedBook,
            loading: false
          });
        }
      }
    });
  };

  const reloadData = async () => {
    Promise.all([
      get(BORROWED_BOOK_FOR_MEMBER_INDEX_API, {
        params: {
          key: state.filter.bookTitle
        }
      }),
    ]).then(([resBorrowedBook]) => {
      if (resBorrowedBook?.success) {
        const responseBorrowedBook = resBorrowedBook?.data;

        if (responseBorrowedBook) {
          setState({
            rowData: responseBorrowedBook,
            loading: false
          });
        }
      }
    });
  };

  const handleCreate = () => {
    if (!authData.active || !authData.canBorrow) {
      Alert.Toast_info(
        "Thông báo",
        "Bạn không được phép mượn sách!",
        Alert.TYPE_ERROR,
        {
          position: "center"
        }
      );
      return;
    }
    const FormCreate = CreateRequestBorrowForm;
    modalRef.current?.onOpen(
      <Suspense fallback={<Loading style={{ height: 300 }} open={true} />}>
        <FormCreate
          reloadData={reloadData}
          apiSave={apiCreate}
          memberId={authData.memberId}
          onClose={() => {
            modalRef.current?.onClose();
          }}
        />
      </Suspense>,
      renderTitleForm('Tạo mới'),
      '850px'
    );
  };

  const handleHistoryBorrow = () => {
    const FormDetail = HistoryBorrowForm;
    modalRef.current?.onOpen(
      <Suspense fallback={<Loading style={{ height: 300 }} open={true} />}>
        <FormDetail
          api={apiHistoryBorrow}
          memberId={authData.memberId}
          onClose={() => {
            modalRef.current?.onClose();
          }}
        />
      </Suspense>,
      renderTitleForm('Lịch sử mượn'),
      '850px'
    );
  };

  function handleDebounceFn(inputValue) {
    setState({
      filter: {
        bookTitle: inputValue
      }
    })
  }

  const debounceFn = useCallback(_.debounce(handleDebounceFn, 500), []);

  function handleChange(event) {
    debounceFn(event.target.value);
  }

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

  const renderLeftActionToolBar = () => {
    return <Form form={form}
                 labelAlign="left"
                 layout={'horizontal'}
                 colon={false}
                 validateTrigger={'onBlur'}>
      <Form.Item name={'bookTitle'}
        // label={'Tìm kiếm'}
                 style={{marginBottom: 0}}
      >
        <Search placeHolder={"Tên sách..."}
                onChange={handleChange}/>
      </Form.Item>
    </Form>
  };

  const renderRightActionToolBar = () => {
    return <div>
      <Tooltip title="Tạo mới"><Button onClick={() => {
        handleCreate()
      }} icon={<PlusOutlined/>} className={'btn-create'}/></Tooltip>
      <Tooltip title="Lịch sử mượn"><Button style={{marginLeft: 5}} onClick={() => {
        handleHistoryBorrow()
      }} icon={<UnorderedListOutlined />} className={'btn-update'}/></Tooltip>
    </div>;
  };

  if (state.loading) {
    return (
      <div className="ag-theme-alpine"
           style={{height: '100%', width: '100%', display: 'flex', justifyContent: 'center', alignItems: 'center'}}>
        <Spin size="large"/>
      </div>
    );
  }

  return (
    <div style={{height: '100%'}}>
      <div className="ag-theme-alpine">
        <CommonGrid
          ref={refGrid}
          actionRow={false}
          renderRightActionToolBar={renderRightActionToolBar}
          columnDefs={bookMemberViewColDef}
          renderLeftActionToolBar={renderLeftActionToolBar}
          rowData={state.rowData}
          isGridDefault={true}
          // reloadData={reloadData}
          formCRUD={{
            popUpWidth: 1100,
            // createForm: BookCreateForm,
            // updateForm: BookUpdateForm,
            // detailForm: BookDetailForm,
          }}
          buttonCRUD={{
            // hasCreate: true,
            // hasDelete: true,
            // hasUpdate: true,
            // hasDetail: true,
            // onCreate: onCreate,
            // onDetailRow: onDetailRow,
            // onEditRow: onEditRow,
            // apiCreate: BOOK_CREATE_API,
            // apiDetail: BOOK_SHOW_API,
            // apiUpdate: BOOK_UPDATE_API,
            // apiDelete: BOOK_DELETE_API
          }}
        />
      </div>
      <BaseModal ref={modalRef} />

    </div>
  );
};

export default MemberHome;