import _ from "lodash";

export const bookColDel = [
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
];