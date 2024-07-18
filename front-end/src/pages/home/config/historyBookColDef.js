import _ from "lodash";
import moment from "moment/moment";

export const historyBookColDef = [
  {headerName: 'Tên', field: 'titleBook', sortable: true, filter: true},
  {
    headerName: 'Nhà xuất bản',
    field: 'publisherName',
    sortable: true,
    filter: true,
    tooltipValueGetter: (params) => {
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
];