import React, {Suspense, useEffect, useRef, useState} from 'react';
import {message, Spin} from 'antd';
import { useRequest } from "../../../custom-hook/useRequest";
import CataloCreateForm from "../form/CataloCreateForm";
import {
  CATALO_CREATE_API,
  CATALO_DELETE_API,
  CATALO_INDEX_API,
  CATALO_SHOW_API,
  CATALO_UPDATE_API
} from "../api/CataloApi";
import CommonGrid from "../../../common/core/grid/CommonGrid";
import CataloUpdateForm from "../form/CataloUpdateForm";
import {cataloColDef} from "../config/cataloColDef";
import Loading from "../../../component/Loading";
import BaseModal from "../../../common/core/Modal/BaseModal";
import {FormOutlined} from "@ant-design/icons";
import {useLocation} from "react-router-dom";
import _ from "lodash";

const CataloListView = () => {
  const [rowData, setRowData] = useState(null);
  const [loading, setLoading] = useState(true);
  const { get } = useRequest();
  const refGrid = useRef(null);
  const modalRef = useRef(null);
  const location = useLocation();
  const pathName = location.pathname.split('/');

  const defaultColDef = {};

  useEffect(() => {
    fetchData();
  }, []);

  const fetchData = async () => {
    try {
      const response = await get(CATALO_INDEX_API + _.last(pathName));
      if (response?.success) {
        setRowData(response?.data);
      } else {
        message.error(response?.message);
      }
    } catch (error) {
      console.error('Error fetching data:', error);
      message.error(error);
    } finally {
      setLoading(false);
    }
  };

  const reloadData = async () => {
    try {
      const response = await get(CATALO_INDEX_API + _.last(pathName));
      if (response?.success) {
        refGrid.current.setRowData(response.data);
      } else {
        message.error(response?.message);
      }
    } catch (error) {
      console.error('Error fetching data:', error);
      message.error(error);
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
        columnDefs={cataloColDef}
        defaultColDef={defaultColDef}
        rowData={rowData}
        isGridDefault={true}
        reloadData={() => reloadData()}
        formCRUD={{
          propsForm: {
            metaCataloId: _.last(pathName),
          },
          createForm: CataloCreateForm,
          updateForm: CataloUpdateForm,
        }}
        buttonCRUD={{
          hasCreate: true,
          hasDelete: true,
          hasUpdate: true,
          // hasDetail: true,
          // onCreate: onCreate,
          // onDetailRow: onDetailRow,
          // onEditRow: onEditRow,
          apiCreate: CATALO_CREATE_API,
          apiDetail: CATALO_SHOW_API,
          apiUpdate: CATALO_UPDATE_API,
          apiDelete: CATALO_DELETE_API
        }}
      />
      <BaseModal ref={modalRef} />
    </div>
  );
};

export default CataloListView;
