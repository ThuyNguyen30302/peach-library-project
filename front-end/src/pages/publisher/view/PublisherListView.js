import React, { useEffect, useRef, useState } from 'react';
import { Spin } from 'antd';
import { useRequest } from "../../../custom-hook/useRequest";
import PublisherCreateForm from "../form/PublisherCreateForm";
import CommonGrid from "../../../common/core/grid/CommonGrid";
import PublisherUpdateForm from "../form/PublisherUpdateForm";
import {
  PUBLISHER_CREATE_API,
  PUBLISHER_DELETE_API,
  PUBLISHER_INDEX_API,
  PUBLISHER_SHOW_API,
  PUBLISHER_UPDATE_API
} from "../api/PublisherApi";
import {publisherColDef} from "../config/publisherColDef";

const PublisherListView = () => {
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
      const response = await get(PUBLISHER_INDEX_API);
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
      const response = await get(PUBLISHER_INDEX_API);
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
        columnDefs={publisherColDef}
        defaultColDef={defaultColDef}
        rowData={rowData}
        isGridDefault={true}
        reloadData={() => reloadData()}
        formCRUD={{
          createForm: PublisherCreateForm,
          updateForm: PublisherUpdateForm,
        }}
        buttonCRUD={{
          hasCreate: true,
          hasDelete: true,
          hasUpdate: true,
          // hasDetail: true,
          // onCreate: onCreate,
          // onDetailRow: onDetailRow,
          // onEditRow: onEditRow,
          apiCreate: PUBLISHER_CREATE_API,
          apiDetail: PUBLISHER_SHOW_API,
          apiUpdate: PUBLISHER_UPDATE_API,
          apiDelete: PUBLISHER_DELETE_API
        }}
      />
    </div>
  );
};

export default PublisherListView;
