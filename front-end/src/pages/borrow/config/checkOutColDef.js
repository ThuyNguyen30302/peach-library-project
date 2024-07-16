import _ from "lodash";
import moment from "moment/moment";
import {Checkbox} from "antd";

export const checkOutColDef = [
  {headerName: 'Thành viên', field: 'memberFullName', sortable: true, filter: true},
  {
    headerName: 'Sách', field: 'titleBook', sortable: true, filter: true, tooltipValueGetter: (params) => {
      return _.isEmpty(params.value) ? "" : params.value;
    }
  },
  {
    headerName: 'Ngày mượn',
    field: 'startTime',
    sortable: true,
    filter: true,
    cellStyle: {textAlign: 'center'},
    maxWidth: 120,
    valueFormatter: (params) => {
      return _.isEmpty(params.value) ? "" : moment(params.value).format('DD-MM-YYYY');
    }
  },
  {
    headerName: 'Hạn trả',
    cellStyle: {textAlign: 'center'},
    field: 'endTime',
    sortable: true,
    filter: true,
    maxWidth: 120,
    valueFormatter: (params) => {
      return _.isEmpty(params.value) ? "" : moment(params.value).format('DD-MM-YYYY');
    }
  },
  {
    headerName: 'Đã trả', field: 'isReturned', sortable: true, filter: true,
    maxWidth: 100,
    cellStyle: {display: 'flex', justifyContent: 'center'},
  },
  {
    headerName: 'Ngày tạo',
    field: 'creationTime',
    sortable: true,
    filter: true,
    maxWidth: 120,
    cellStyle: {textAlign: 'center'},
    valueFormatter: (params) => {
      return _.isEmpty(params.value) ? "" : moment(params.value).format('DD-MM-YYYY');
    }
  },
];