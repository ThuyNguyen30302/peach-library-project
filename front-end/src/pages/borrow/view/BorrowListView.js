import React, { useEffect, useRef, useState } from 'react';
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

const BorrowListView = () => {
  const [rowData, setRowData] = useState(null);
  const [loading, setLoading] = useState(true);
  const { get } = useRequest();
  const refGrid = useRef(null);

  const defaultColDef = {};

  useEffect(() => {
    fetchData();
  }, []);

  const fetchData = async () => {
    try {
      const response = await get(CHECK_OUT_INDEX_API);
      if (response?.success) {
        setRowData(response?.data);
      } else {
        // ToastUtil.ToastApiError(response?.message);
      }
    } catch (error) {
      console.error('Error fetching data:', error);
      // ToastUtil.ToastServerError(error.message);
    } finally {
      setLoading(false);
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
      setLoading(false);
    }
  }

  if (loading) {
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
        rowData={rowData}
        isGridDefault={true}
        reloadData={() => reloadData()}
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
