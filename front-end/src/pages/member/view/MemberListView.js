import React, { useEffect, useRef, useState } from 'react';
import { Spin } from 'antd';
import { useRequest } from "../../../custom-hook/useRequest";
import MemberCreateForm from "../form/MemberCreateForm";
import CommonGrid from "../../../common/core/grid/CommonGrid";
import MemberUpdateForm from "../form/MemberUpdateForm";
import {
  MEMBER_CREATE_API,
  MEMBER_DELETE_API,
  MEMBER_INDEX_API,
  MEMBER_SHOW_API,
  MEMBER_UPDATE_API
} from "../api/MemberApi";
import {memberColDef} from "../config/memberColDef";

const MemberListView = () => {
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
      const response = await get(MEMBER_INDEX_API);
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
      const response = await get(MEMBER_INDEX_API);
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
        columnDefs={memberColDef}
        defaultColDef={defaultColDef}
        rowData={rowData}
        isGridDefault={true}
        reloadData={() => reloadData()}
        popUpWidth={1100}
        formCRUD={{
          createForm: MemberCreateForm,
          updateForm: MemberUpdateForm,
        }}
        buttonCRUD={{
          hasCreate: true,
          hasDelete: true,
          hasUpdate: true,
          hasDetail: true,
          // onCreate: onCreate,
          // onDetailRow: onDetailRow,
          // onEditRow: onEditRow,
          apiCreate: MEMBER_CREATE_API,
          apiDetail: MEMBER_SHOW_API,
          apiUpdate: MEMBER_UPDATE_API,
          apiDelete: MEMBER_DELETE_API
        }}
      />
    </div>
  );
};

export default MemberListView;
