import React, {useEffect, useMemo, useRef} from 'react';
import {DatePicker, Form, Spin} from 'antd';
import {useRequest} from "../../../custom-hook/useRequest";
import {
  BOOK_COMBO_OPTION_API,
  IMPORT_BOOK_CREATE_API,
  IMPORT_BOOK_DELETE_API,
  IMPORT_BOOK_INDEX_API, IMPORT_BOOK_SHOW_API,
  IMPORT_BOOK_UPDATE_API, PUBLISHER_COMBO_OPTION_API
} from "../api/ImportBookApi";
import CommonGrid from "../../../common/core/grid/CommonGrid";
import {importBookColDef, importBookColDel} from "../config/importBookColDel";
import useMergeState from "../../../custom-hook/useMergeState";
import {BOOK_TYPE_COMBO_OPTION_CODE_API} from "../../book/api/BookApi";
import ImportBookCreateForm from "../form/ImportBookCreateForm";
import ImportBookUpdateForm from "../form/ImportBookUpdateForm";
import {AgGridReact} from "ag-grid-react";
import "ag-grid-community/styles/ag-grid.css";
import "ag-grid-community/styles/ag-theme-quartz.css";

import 'ag-grid-community/styles/ag-theme-balham.css';
import _ from "lodash";
import moment from "moment";
import BaseForm from "../../../common/core/Form/BaseForm";
import CustomDatePicker from "../../../common/DatePicker/CustomDatePicker";
import dayjs from "dayjs";
const { RangePicker } = DatePicker;
const dateFormat = 'YYYY-MM-DD';

const ImportBookListView = () => {
  const [state, setState] = useMergeState({
    comboOptionBook: [],
    comboOptionPublisher: [],
    comboOptionBookType: [],
    rowData: [],
    loading: true,
    filter: {
      startDate: moment().format('YYYY-MM-DD'),
      endDate: moment().format('YYYY-MM-DD')
    }
  });
  const {get} = useRequest();
  const refGrid = useRef(null);
  const [form] = Form.useForm();

  const defaultColDef = {};

  useEffect(() => {
    loadCombo();
    fetchData();
  }, [state.filter]);

  const loadCombo = async () => {
    Promise.all([
      get(BOOK_COMBO_OPTION_API),
      get(PUBLISHER_COMBO_OPTION_API),
      get(BOOK_TYPE_COMBO_OPTION_CODE_API),
    ]).then(([resComboBook, resComboPublisher, resComboBookType]) => {
      if (resComboBook?.success && resComboPublisher?.success && resComboBookType?.success) {
        const responseComboBook = resComboBook?.data;
        const responseComboPublisher = resComboPublisher?.data;
        const responseComboBookType = resComboBookType?.data;
        if (responseComboBook && responseComboPublisher && responseComboBookType) {
          setState({
            comboOptionBook: responseComboBook,
            comboOptionPublisher: responseComboPublisher,
            comboOptionBookType: responseComboBookType
          });
        }
      }
    });
  };

  const beforSetValue = (data) => {
    _.each(data, (value, key) => {
      const yearPublisher = _.get(value, 'yearPublisher');
      const creationTime = _.get(value, 'creationTime');
      _.set(value, 'yearPublisher', moment(yearPublisher).format('DD-MM-YYYY'));
      _.set(value, 'creationTime', moment(creationTime).format('DD-MM-YYYY HH:mm'));
    })
    return data;
  }

  const fetchData = async () => {
    try {
      const filter = state.filter;
      const response = await get(IMPORT_BOOK_INDEX_API, {
        params: {...filter}
      });
      if (response?.success) {
        const value = beforSetValue(response?.data);
        setState({
          rowData: value
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

      const filter = state.filter;
      const response = await get(IMPORT_BOOK_INDEX_API, {
        params: {...filter}
      });
      if (response?.success) {
        const value = beforSetValue(response?.data);

        refGrid.current.setRowData(value);
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

  const renderLeftActionToolBar = () => {
    return <Form form={form}
                 labelAlign="left"
                 layout={'horizontal'}
                 colon={false}
                 validateTrigger={'onBlur'}>
      <Form.Item name={'filter'}
                 label={'Ngày nhập kho'}
                 style={{marginBottom: 0}}
      >
        <CustomDatePicker type={'dateRange'}
                          name={'filter'}
                          showTime={false}
                          format={"DD-MM-YYYY"}
                          defaultValue={[dayjs(), dayjs()]}
                          allowClear={false}
                          onChange={(e) => {
                            const startDate = _.first(e).format('YYYY-MM-DD');
                            const endDate = _.last(e).format('YYYY-MM-DD');
                            setState({
                              filter: {
                                startDate: startDate,
                                endDate: endDate,
                              }
                            })
                          }}
        />
      </Form.Item>
    </Form>
  };

  if (state.loading) {
    return (
      <div className="ag-theme-alpine"
           style={{height: '100%', width: '100%', display: 'flex', justifyContent: 'center', alignItems: 'center'}}>
        <Spin size="large"/>
      </div>
    );
  }

  return (
    <div className="ag-theme-alpine">
      <CommonGrid
        ref={refGrid}
        renderLeftActionToolBar={renderLeftActionToolBar}
        animateRows={true}
        numberRow={false}
        actionRow={false}
        columnDefs={importBookColDef()}
        defaultColDef={defaultColDef}
        rowData={state.rowData}
        reloadData={() => reloadData()}
        formCRUD={{
          propsForm: {
            comboOptionBook: state.comboOptionBook,
            comboOptionPublisher: state.comboOptionPublisher
          },
          popUpWidth: 1100,
          createForm: ImportBookCreateForm,
          updateForm: ImportBookUpdateForm,
        }}
        buttonCRUD={{
          hasCreate: true,
          // hasDelete: true,
          // hasUpdate: true,
          // hasDetail: true,
          // onCreate: onCreate,
          // onDetailRow: onDetailRow,
          // onEditRow: onEditRow,
          apiCreate: IMPORT_BOOK_CREATE_API,
          apiDetail: IMPORT_BOOK_SHOW_API,
          // apiUpdate: IMPORT_BOOK_UPDATE_API,
          // apiDelete: IMPORT_BOOK_DELETE_API
        }}
      />
    </div>
  );
};

export default ImportBookListView;
