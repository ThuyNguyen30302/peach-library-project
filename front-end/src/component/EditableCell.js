// EditTableCell.js
import React from 'react';
import { Form, Input, Select, DatePicker } from 'antd';

const EditTableCell = ({
                         editing,
                         dataIndex,
                         title,
                         inputType,
                         record,
                         index,
                         children,
                         options = [],
                         ...restProps
                       }) => {
  let inputNode;
  switch (inputType) {
    case 'select':
      inputNode = <Select>{options.map(opt => <Select.Option key={opt.value} value={opt.value}>{opt.label}</Select.Option>)}</Select>;
      break;
    case 'number':
      inputNode = <Input type="number" />;
      break;
    case 'date':
      inputNode = <DatePicker />;
      break;
    case 'textarea':
      inputNode = <Input.TextArea />;
      break;
    default:
      inputNode = <Input />;
  }

  return (
    <td {...restProps}>
      {editing ? (
        <Form.Item
          name={dataIndex}
          style={{ margin: 0 }}
          rules={[{ required: true, message: `Please Input ${title}!` }]}
        >
          {inputNode}
        </Form.Item>
      ) : (
        children
      )}
    </td>
  );
};

export default EditTableCell;
