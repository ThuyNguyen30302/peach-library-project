import _ from "lodash";

export const importBookColDef = () => {
  return [
    {
      headerName: 'Sách',
      field: 'bookName',
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
      headerName: 'Ngày xuất bản',
      field: 'yearPublisher',
      sortable: true,
      filter: true,
      cellStyle: {textAlign: 'center'}
    },
    {
      headerName: 'Số lượng',
      field: 'amount',
      maxWidth: 120,
      sortable: true,
      filter: true,
      cellStyle: {textAlign: 'center'}
    },
    {
      headerName: 'Ngày nhập kho',
      field: 'creationTime',
      sortable: true,
      filter: true,
      cellStyle: {textAlign: 'center'}
    },

    // { headerName: 'Tên',
    // field: 'title',
    // sortable: true,
    // filter: true },
    // {
    //   headerName: 'Tác giả',
    //   field: 'authors',
    //   sortable: true,
    //   filter: true,
    //   tooltipValueGetter: (params) => {
    //     return _.isEmpty(params.value) ? "" : params.value;
    //   }
    // },
    // {
    //   headerName: 'Thể loại',
    //   field: 'types',
    //   sortable: true,
    //   filter: true,
    //   tooltipValueGetter: (params) => {
    //     return _.isEmpty(params.value) ? "" : params.value;
    //   }
    // },
  ];
};