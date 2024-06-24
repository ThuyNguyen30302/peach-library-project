import React, { useEffect, useRef, useState } from 'react';
import { Spin } from 'antd';
import { useRequest } from "../../../custom-hook/useRequest";
import MetaCataloCreateForm from "../form/MetaCataloCreateForm";
import {
  METACATALO_CREATE_API,
  METACATALO_DELETE_API,
  METACATALO_INDEX_API,
  METACATALO_SHOW_API,
  METACATALO_UPDATE_API
} from "../api/MetaCataloApi";
import CommonGrid from "../../../common/core/grid/CommonGrid";
import MetaCataloUpdateForm from "../form/MetaCataloUpdateForm";
import {metacataloColDef} from "../config/metacataloColDef";
import {useNavigate} from "react-router-dom";

const MetaCataloListView = () => {
  const [rowData, setRowData] = useState(null);
  const [loading, setLoading] = useState(true);
  const { get } = useRequest();
  const refGrid = useRef(null);
  const navigate = useNavigate();

  const defaultColDef = {};

  useEffect(() => {
    fetchData();
  }, []);

  const fetchData = async () => {
    try {
      const response = await get(METACATALO_INDEX_API);
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
      const response = await get(METACATALO_INDEX_API);
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

  const onDetailRow = (data) => {
    navigate(`/config/metacatalo/catalo/${data?.id}`);
  };

  return (
    <div className="ag-theme-alpine">
      <CommonGrid
        ref={refGrid}
        columnDefs={metacataloColDef}
        defaultColDef={defaultColDef}
        rowData={rowData}
        isGridDefault={true}
        reloadData={() => reloadData()}
        formCRUD={{
          createForm: MetaCataloCreateForm,
          updateForm: MetaCataloUpdateForm,
        }}
        buttonCRUD={{
          hasCreate: true,
          hasDelete: true,
          hasUpdate: true,
          hasDetail: true,
          // onCreate: onCreate,
          onDetailRow: onDetailRow,
          // onEditRow: onEditRow,
          apiCreate: METACATALO_CREATE_API,
          apiDetail: METACATALO_SHOW_API,
          apiUpdate: METACATALO_UPDATE_API,
          apiDelete: METACATALO_DELETE_API
        }}
      />
    </div>
  );
};

export default MetaCataloListView;
