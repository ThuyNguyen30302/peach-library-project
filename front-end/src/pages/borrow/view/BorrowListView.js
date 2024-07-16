import React, { useEffect, useRef } from 'react';
import { Spin } from 'antd';
import { useRequest } from "../../../custom-hook/useRequest";
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

const BorrowListView = () => {
  const { get } = useRequest();
  const refGrid = useRef(null);

  const [state, setState] = useMergeState({
    comboOptionBook: [],
    comboOptionMember: [],
    rowData: [],
    loading: true,
  });

  const defaultColDef = {};

  useEffect(() => {
    loadCombo();
    fetchData();
  }, []);

  const loadCombo = async () => {
    Promise.all([
      get(BOOK_COMBO_OPTION_CAN_BORROW_API),
      get(MEMBER_COMBO_OPTION_CAN_BORROW_API),
    ]).then(([resComboBook, resComboMember]) => {
      if (resComboBook?.success && resComboMember?.success) {
        const responseComboBook = resComboBook?.data;
        const responseComboMember = resComboMember?.data;
        if (responseComboBook && responseComboMember) {
          setState({
            comboOptionBook: responseComboBook,
            comboOptionMember: responseComboMember,
          });
        }
      }
    });
  };

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
        columnDefs={checkOutColDef}
        defaultColDef={defaultColDef}
        rowData={state.rowData}
        isGridDefault={true}
        reloadData={() => reloadData()}
        formCRUD={{
          propsForm: {
            comboOptionBook: state.comboOptionBook,
            comboOptionMember: state.comboOptionMember
          },
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
