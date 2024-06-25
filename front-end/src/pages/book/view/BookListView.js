import React, { useEffect, useRef, useState } from 'react';
import { Spin } from 'antd';
import { useRequest } from "../../../custom-hook/useRequest";
import BookCreateForm from "../form/BookCreateForm";
import {
  AUTHOR_COMBO_OPTION_API,
  BOOK_CREATE_API,
  BOOK_DELETE_API,
  BOOK_INDEX_API,
  BOOK_SHOW_API, BOOK_TYPE_COMBO_OPTION_CODE_API,
  BOOK_UPDATE_API
} from "../api/BookApi";
import CommonGrid from "../../../common/core/grid/CommonGrid";
import BookUpdateForm from "../form/BookUpdateForm";
import {bookColDel} from "../config/bookColDel";
import useMergeState from "../../../custom-hook/useMergeState";

const BookListView = () => {
  const [state, setState] = useMergeState({
    comboOptionAuthor : [],
    comboOptionBookType : [],
    rowData: [],
    loading: true,
  });
  const { get } = useRequest();
  const refGrid = useRef(null);

  const defaultColDef = {};

  useEffect(() => {
    loadCombo();
    fetchData();
  }, []);

  const loadCombo = async () => {
    Promise.all([
      get(AUTHOR_COMBO_OPTION_API),
      get(BOOK_TYPE_COMBO_OPTION_CODE_API),
    ]).then(([resComboAuthor, resComboBookType]) => {
      if (resComboAuthor?.success && resComboBookType?.success) {
        const responseComboAuthor = resComboAuthor?.data;
        const responseComboBookType = resComboBookType?.data;
        if (responseComboAuthor && responseComboBookType) {
          setState({
            comboOptionAuthor: responseComboAuthor,
            comboOptionBookType: responseComboBookType
          });
        }
      }
    });
  };

  const fetchData = async () => {
    try {
      const response = await get(BOOK_INDEX_API);
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
        columnDefs={bookColDel}
        defaultColDef={defaultColDef}
        rowData={state.rowData}
        isGridDefault={true}
        reloadData={() => reloadData()}
        formCRUD={{
          propsForm: {
            comboOptionBookType: state.comboOptionBookType,
            comboOptionAuthor: state.comboOptionAuthor
          },
          createForm: BookCreateForm,
          updateForm: BookUpdateForm,
        }}
        buttonCRUD={{
          hasCreate: true,
          hasDelete: true,
          hasUpdate: true,
          // hasDetail: true,
          // onCreate: onCreate,
          // onDetailRow: onDetailRow,
          // onEditRow: onEditRow,
          apiCreate: BOOK_CREATE_API,
          apiDetail: BOOK_SHOW_API,
          apiUpdate: BOOK_UPDATE_API,
          apiDelete: BOOK_DELETE_API
        }}
      />
    </div>
  );
};

export default BookListView;
