import React, { useEffect, useRef, useState } from 'react';
import { Spin } from 'antd';
import { useRequest } from "../../../custom-hook/useRequest";
import CommonGrid from "../../../common/core/grid/CommonGrid";
import useMergeState from "../../../custom-hook/useMergeState";
import {BOOK_INDEX_API} from "../../book/api/BookApi";
import {BORROWED_BOOK_INDEX_API} from "../api/BorrowApi";
import {borrowedBookColDel} from "../config/borrowedBookColDel";

const BorrowBookListView = () => {
  const [state, setState] = useMergeState({
    rowData: [],
    loading: true,
  });
  const { get } = useRequest();
  const refGrid = useRef(null);

  const defaultColDef = {};

  useEffect(() => {
    fetchData();
  }, []);

  const fetchData = async () => {
    try {
      const response = await get(BORROWED_BOOK_INDEX_API);
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
      const response = await get(BOOK_INDEX_API);
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
        columnDefs={borrowedBookColDel}
        defaultColDef={defaultColDef}
        rowData={state.rowData}
        actionRow={false}
        isGridDefault={true}
        reloadData={() => reloadData()}
        formCRUD={{
          propsForm: {},
          // popUpWidth: 1100,
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
  );
};

export default BorrowBookListView;
