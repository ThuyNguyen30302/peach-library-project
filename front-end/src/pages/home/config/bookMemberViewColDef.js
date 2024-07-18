import _ from "lodash";

export const bookMemberViewColDef = [
  {headerName: 'Tên', field: 'title', sortable: true, filter: true},
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
    headerName: 'Có sẵn',
    field: 'available',
    sortable: true,
    filter: true,
    maxWidth: 120,
    cellStyle: {display: 'flex', justifyContent: 'center'},
    tooltipValueGetter: (params) => {
      return _.isEmpty(params.value) ? "" : params.value;
    }
  },
];