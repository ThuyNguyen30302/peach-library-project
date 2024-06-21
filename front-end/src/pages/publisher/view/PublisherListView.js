import React, { useEffect, useRef, useState } from 'react';
import { Spin } from 'antd';
import { API_LOCAL } from "../../../constant/ApiConstant";
import { useRequest } from "../../../custom-hook/useRequest";
import BaseListView from "../../../common/core/grid/BaseListView";
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
// import ToastUtil from "../../../util/ToastUtil"; // Đảm bảo đường dẫn chính xác

const PublisherListView = () => {
  const [rowData, setRowData] = useState(null);
  const [loading, setLoading] = useState(true);
  const { get } = useRequest();
  const refGrid = useRef(null); // Sửa lại chỗ này để đúng cách sử dụng useRef

  const columnDefs = [
    { headerName: 'STT', valueGetter: 'node.rowIndex + 1', maxWidth: 80, cellStyle: { textAlign: 'center' } },
    { headerName: 'Tên', field: 'name', sortable: true, filter: true, minWidth: 300 },
    { headerName: 'Mã', field: 'code', sortable: true, filter: true, minWidth: 300 },
  ];

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
      // ToastUtil.ToastServerError(error.message); // Thêm thông báo lỗi khi có lỗi xảy ra
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
      // ToastUtil.ToastServerError(error.message); // Thêm thông báo lỗi khi có lỗi xảy ra
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
    <div className="ag-theme-alpine"
         style={{
           // height: '100%',
           // width: '100%'
    }}
    >
      <CommonGrid
        ref={refGrid}
        columnDefs={columnDefs}
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
