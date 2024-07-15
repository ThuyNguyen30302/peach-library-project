import React, {useEffect, useRef} from 'react';
import _ from "lodash";
import {Spin} from "antd";
import CommonGrid from "../../../common/core/grid/CommonGrid";
import {
  BOOK_lIST_DETAIL_API
} from "../api/BookApi";
import useMergeState from "../../../custom-hook/useMergeState";
import {useRequest} from "../../../custom-hook/useRequest";
import {bookDetailColDel} from "../config/bookDetailColDef";

const BookDetailForm = (props) => {
  const formRef = useRef(null);

  const beforeSetValue = (data) => {
    const authors = _.map(data.bookAuthorMappings, x => {return x.authorId});
    const type = _.split(_.get(data, 'type'), ',');
    _.set(data, 'authors', authors);
    _.set(data, 'type', type);

    return data;
  };
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
      const response = await get(BOOK_lIST_DETAIL_API + '/' + props.id);
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
        columnDefs={bookDetailColDel}
        defaultColDef={defaultColDef}
        actionRow={false}
        rowData={state.rowData}
        formCRUD={{}}
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

export default BookDetailForm;