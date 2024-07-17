import _ from "lodash";

export const borrowedBookColDel = [
  {
    headerName: 'Tên sách', field: 'title', sortable: true, filter: true,
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
    headerName: 'Số lượng đã mượn',
    field: 'borrowedBookAmount',
    cellStyle: {textAlign: 'center'},
  },
  {
    headerName: 'Số lượng có sẵn',
    field: 'availableBookAmount',
    cellStyle: {textAlign: 'center'},
  },
];