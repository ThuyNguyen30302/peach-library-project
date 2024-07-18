import _ from "lodash";
import moment from "moment";

export const memberColDef = [
  {headerName: 'Tên', field: 'name', sortable: true, filter: true, minWidth: 200},
  // {headerName: 'Tài khoản', field: 'userName', sortable: true, filter: true, minWidth: 120},
  {headerName: 'SĐT', field: 'phoneNumber', sortable: true, filter: true, minWidth: 120},
  {
    headerName: 'Email',
    field: 'email',
    sortable: true,
    filter: true,
    minWidth: 200,
    tooltipValueGetter: (params) => {
      return _.isEmpty(params.value) ? "" : params.value;
    }
  },
  {headerName: 'CCCD', field: 'cardNumber', sortable: true, filter: true, minWidth: 140},
  {
    headerName: 'Ngày sinh',
    field: 'doB',
    sortable: true,
    filter: true,
    minWidth: 120,
    valueFormatter: (params) => {
      return _.isEmpty(params.value) ? "" : moment(params.value).format('DD-MM-YYYY');
    }
  },
  {
    headerName: 'Trạng thái', field: 'status', sortable: true, filter: true, minWidth: 150, pinned: 'right',
    valueFormatter: (params) => {
      return params.value === "ACTIVE" ? "Hoạt động" : "Không hoạt động";
    }
  },
  {
    headerName: 'Địa chỉ',
    field: 'address',
    sortable: true,
    filter: true,
    tooltip: true,
    minWidth: 200,
    tooltipValueGetter: (params) => {
      return _.isEmpty(params.value) ? "" : params.value;
    }
  },
  {
    headerName: 'Ngày tạo',
    field: 'creationTime',
    sortable: true,
    filter: true,
    minWidth: 120,
    valueFormatter: (params) => {
      return _.isEmpty(params.value) ? "" : moment(params.value).format('DD-MM-YYYY');
    }
  },
];