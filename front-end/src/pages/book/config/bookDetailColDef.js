import _ from "lodash";

export const bookDetailColDel = [
  {headerName: 'Tên', field: 'title', sortable: true, filter: true},
  {
    headerName: 'Tác giả',
    field: 'authors',
    sortable: true,
    filter: true,
    tooltipValueGetter: (params) => {
      return _.isEmpty(params.value) ? "" : params.value;
    }
  },
  {
    headerName: 'Thể loại',
    field: 'types',
    sortable: true,
    filter: true,
    tooltipValueGetter: (params) => {
      return _.isEmpty(params.value) ? "" : params.value;
    }
  },
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
    headerName: 'Số lượng',
    field: 'amount',
    sortable: true,
    filter: true,
    maxWidth: 120,
    cellStyle: {textAlign: 'center'},
    tooltipValueGetter: (params) => {
      return _.isEmpty(params.value) ? "" : params.value;
    }
  },
];