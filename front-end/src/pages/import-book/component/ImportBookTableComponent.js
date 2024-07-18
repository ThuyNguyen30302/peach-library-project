import {useState} from "react";
import {Button, Form, Input, InputNumber, Select, Space, Table} from "antd";
import {PlusOutlined, DeleteOutlined} from "@ant-design/icons";
import CustomDatePicker from "../../../common/DatePicker/CustomDatePicker";
import AppUtil from "../../../util/AppUtil";

const trimStringFormatter = value =>
  typeof value === "string" ? value.trim() : value;

const getUniqFieldRule = (collectionFieldNamePath, propName, errorMessage) => ({
                                                                                 getFieldValue
                                                                               }) => ({
  validator(_, value) {
    if (value) {
      const collection = getFieldValue(collectionFieldNamePath);
      if (
        collection &&
        collection.length &&
        collection.find(i => !i._editing && i[propName] === value)
      ) {
        return Promise.reject(new Error(errorMessage));
      }
    }
    return Promise.resolve();
  }
});

const FieldUpdater = props => {
  const {value, onChange, children} = props;
  return children({value, onChange});
};

const ImportBookTableComponent = ({name: prefix, form, combo, operatable = false}) => {
  const [_ic, _setIc] = useState(false);
  const forceUpdateTable = () => _setIc(!_ic);

  return (
    <Form.List name={prefix}>
      {(fields, {add, remove}) => {
        const append = () => add({amount: 1});

        const columns = [
          {
            key: "bookId",
            title: "Sách",
            width: 250,
            render: (_, field) => {
              const propName = "bookId";
              return (
                <Form.Item
                  {...field}
                  label={'Sách'}
                  className="in-cell-field"
                  name={[field.name, propName]}
                  fieldKey={[field.fieldKey, propName]}
                  rules={[
                    {
                      required: true,
                    },
                  ]}
                >
                  <Select
                    style={{ width: 250 }}
                    filterOption={(input, option) => (option?.label ?? '').toLowerCase().includes(input.toLowerCase())}
                    options={combo.comboOptionBook}
                    showSearch={true}
                  ></Select>
                </Form.Item>
              );
            }
          },
          {
            key: "publisherId",
            title: "Nhà xuất bản",
            width: 250,
            render: (_, field) => {
              const propName = "publisherId";
              return (
                <Form.Item
                  {...field}
                  label={'Nhà xuất bản'}
                  className="in-cell-field"
                  name={[field.name, propName]}
                  fieldKey={[field.fieldKey, propName]}
                  rules={[
                    {
                      required: true,
                    },
                  ]}
                >
                  <Select
                    style={{ width: 250 }}
                    filterOption={(input, option) => (option?.label ?? '').toLowerCase().includes(input.toLowerCase())}
                    options={combo.comboOptionPublisher}
                    showSearch={true}
                  ></Select>
                </Form.Item>
              );
            }
          },
          {
            key: "amount",
            title: "Số lượng",
            width: 100,
            render: (_, field) => {
              const propName = "amount";
              return (
                <Form.Item
                  {...field}
                  label={'Số lượng'}
                  className="in-cell-field"
                  name={[field.name, propName]}
                  fieldKey={[field.fieldKey, propName]}
                  rules={[
                    {
                      required: true,
                    },
                  ]}
                >
                  <Input
                    min={1}
                    onKeyPress={(event) => {
                      if (!/[0-9]/.test(event.key)) {
                        event.preventDefault();
                      }
                    }}
                  />
                </Form.Item>
              );
            }
          },
          {
            key: "price",
            title: "Giá nhập",
            width: 120,
            render: (_, field) => {
              const propName = "price";
              return (
                <Form.Item
                  {...field}
                  label={'Giá nhập'}
                  className="in-cell-field"
                  name={[field.name, propName]}
                  fieldKey={[field.fieldKey, propName]}
                  rules={[
                    {
                      required: true,
                    },
                  ]}
                >
                  <Input
                    min={0}
                    onKeyPress={(event) => {
                      if (!/[0-9]/.test(event.key)) {
                        event.preventDefault();
                      }
                    }}
                  />
                </Form.Item>
              );
            }
          },
          {
            key: "yearPublisher",
            title: "Ngày xuất bản",
            width: 120,
            render: (_, field) => {
              const propName = "yearPublisher";
              return (
                <Form.Item
                  {...field}
                  label={'Năm xuất bản'}
                  className="in-cell-field"
                  name={[field.name, propName]}
                  fieldKey={[field.fieldKey, propName]}
                  rules={[
                    {
                      required: true,
                    },
                  ]}
                >
                  <CustomDatePicker
                    type={'year'}
                    format={'YYYY'}
                    submitFormat
                    showTime={false}
                    allowClear={false}
                  />
                </Form.Item>
              );
            }
          },
          {
            title: 'Hành động',
            key: 'action',
            width: 50,
            render: (_, field) => (
              <div style={{ height: '100%' }}>
                <Button
                  type="primary"
                  danger
                  icon={<DeleteOutlined />}
                  onClick={() => remove(field.name)}
                  disabled={fields.length === 1}
                />
              </div>
            ),
          },
        ];

        return (
          <>
            <Table dataSource={fields} pagination={false} columns={columns} rowKey="name" />
            <Button
              type="dashed"
              block
              style={{margin: "16px 0"}}
              onClick={append}
            >
              <PlusOutlined /> Thêm dữ liệu
            </Button>
          </>
        );
      }}
    </Form.List>
  );
};

export default ImportBookTableComponent;
