import React, { useEffect, useRef, useState } from 'react';
import { Spin } from 'antd';
import { useRequest } from "../../../custom-hook/useRequest";
import AuthorCreateForm from "../form/AuthorCreateForm";
import {
  AUTHOR_CREATE_API,
  AUTHOR_DELETE_API,
  AUTHOR_INDEX_API,
  AUTHOR_SHOW_API,
  AUTHOR_UPDATE_API
} from "../api/AuthorApi";
import CommonGrid from "../../../common/core/grid/CommonGrid";
import AuthorUpdateForm from "../form/AuthorUpdateForm";
import {authorColDel} from "../config/authorColDel";

const AuthorListView = () => {
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
      const response = await get(AUTHOR_INDEX_API);
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
      const response = await get(AUTHOR_INDEX_API);
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
        columnDefs={authorColDel}
        defaultColDef={defaultColDef}
        rowData={rowData}
        isGridDefault={true}
        reloadData={() => reloadData()}
        formCRUD={{
          createForm: AuthorCreateForm,
          updateForm: AuthorUpdateForm,
        }}
        buttonCRUD={{
          hasCreate: true,
          hasDelete: true,
          hasUpdate: true,
          // hasDetail: true,
          // onCreate: onCreate,
          // onDetailRow: onDetailRow,
          // onEditRow: onEditRow,
          apiCreate: AUTHOR_CREATE_API,
          apiDetail: AUTHOR_SHOW_API,
          apiUpdate: AUTHOR_UPDATE_API,
          apiDelete: AUTHOR_DELETE_API
        }}
      />
    </div>
  );
};

export default AuthorListView;
