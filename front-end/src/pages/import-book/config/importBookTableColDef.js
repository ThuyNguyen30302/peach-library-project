import _ from "lodash";
import {Form, Input, Select} from "antd";

export const importBookTableColDel = (comboOptionBook, comboOptionPublisher) => {
  return [
    {
      title: 'Sách',
      dataIndex: 'book',
      sortable: false,
      filter: false,
      render: (_, record, i) => {
        return <Form.Item {...record} name={[record.namme, 'book']}>
          <Select name={[record.name, 'book']} options={comboOptionBook}></Select>
        </Form.Item>
      }
    },
    // {
    //   title: 'Nhà xuất bản',
    //   dataIndex: 'publisher',
    //   sortable: false,
    //   filter: false,
    //   render: (_, record, i) => {
    //     return <Form.Item name={`importBooks[${i}].publisher`}>
    //       <Select name={`importBooks[${i}].publisher`} options={comboOptionPublisher}></Select>
    //     </Form.Item>
    //   }
    // },
    // {
    //   title: 'Số lượng',
    //   dataIndex: 'amount',
    //   sortable: false,
    //   filter: false,
    //   render: (_, record, i) => {
    //     return <Form.Item name={`importBooks[${i}].amount`}>
    //       <Input name={`importBooks[${i}].amount`}
    //              onKeyPress={(event) => {
    //                if (!/[0-9]/.test(event.key)) {
    //                  event.preventDefault();
    //                }
    //              }}/>
    //     </Form.Item>
    //   }
    // },
    // {
    //   title: 'Hành động',
    //   dataIndex: 'action',
    //   render: (_, record, i) => {
    //   }
    //   // dataSource.length >= 1 ? (
    //   //   <Popconfirm title="Sure to delete?" onConfirm={() => handleDelete(record.key)}>
    //   //     <a>Delete</a>
    //   //   </Popconfirm>
    //   // ) : null,
    // },
  ];
}