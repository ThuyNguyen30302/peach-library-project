import React, { useEffect, useRef, useState } from 'react';
import { Spin } from 'antd';
import { useRequest } from "../../../custom-hook/useRequest";
import MemberCreateForm from "../form/MemberCreateForm";
import CommonGrid from "../../../common/core/grid/CommonGrid";
import MemberUpdateForm from "../form/MemberUpdateForm";
import {
  MEMBER_COMBO_OPTION_CODE_API,
  MEMBER_CREATE_API,
  MEMBER_DELETE_API,
  MEMBER_INDEX_API,
  MEMBER_SHOW_API,
  MEMBER_UPDATE_API
} from "../api/MemberApi";
import {memberColDef} from "../config/memberColDef";
import useMergeState from "../../../custom-hook/useMergeState";

const MemberListView = () => {
  const { get } = useRequest();
  const refGrid = useRef(null);
  const defaultColDef = {};

  const [state, setState] = useMergeState({
    comboMemberStatus : [],
    rowData: [],
    loading: true,
  });

  useEffect(() => {
    loadCombo();
    fetchData();
  }, []);

  const loadCombo = async () => {
    Promise.all([
      get(MEMBER_COMBO_OPTION_CODE_API),
    ]).then(([resCombo]) => {
      if (resCombo?.success) {
        const responseCombo = resCombo?.data;
        if (responseCombo) {
          setState({
            comboMemberStatus: responseCombo,
          });
        }
      }
    });
  };

  const fetchData = async () => {
    try {
      const response = await get(MEMBER_INDEX_API);
      if (response?.success) {
        setState({
          rowData: response?.data
        });
      } else {
      }
    } catch (error) {
      console.error('Error fetching data:', error);
    } finally {
      setState({
        loading: false
      });
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
        columnDefs={memberColDef}
        defaultColDef={defaultColDef}
        rowData={state.rowData}
        isGridDefault={true}
        reloadData={() => reloadData()}
        popUpWidth={1100}
        formCRUD={{
          propsForm: {
            comboMemberStatus: state.comboMemberStatus
          },
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
