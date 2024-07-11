import {useState} from "react";
import {Button, Form, Input, InputNumber, Select, Space, Table} from "antd";
import {PlusOutlined} from "@ant-design/icons";
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
            width: "25%",
            render: (_, field) => {
              const propName = "bookId";
              // const { book: value } = form.getFieldValue([
              //   prefix,
              //   field.name
              // ]);
              return <Form.Item
                {...field}
                label={'Sách'}
                className="in-cell-field"
                name={[field.name, propName]}
                fieldKey={[field.fieldKey, propName]}
                rules={[
                  {
                    required: true,
                  },
                  // getUniqFieldRule([prefix], propName, "duplicate!")
                ]}
              >
                <Select options={combo.comboOptionBook}></Select>
              </Form.Item>
            }
          },
          {
            key: "publisherId",
            title: "Nhà sản xuất",
            width: "25%",
            render: (_, field) => {
              const propName = "publisherId";
              // const { age: value } = form.getFieldValue([
              //   prefix,
              //   field.name
              // ]);

              return <Form.Item
                {...field}
                label={'Nhà sản xuất'}
                className="in-cell-field"
                name={[field.name, propName]}
                rules={[
                  {
                    required: true,
                  },
                ]}
                fieldKey={[field.fieldKey, propName]}
              >
                <Select options={combo.comboOptionPublisher}></Select>
              </Form.Item>
            }
          },
          {
            key: "amount",
            title: "Số lượng",
            width: "15%",
            render: (_, field) => {
              const propName = "amount";
              // const { age: value } = form.getFieldValue([
              //   prefix,
              //   field.name
              // ]);

              return <Form.Item
                {...field}
                label={'Số lượng'}
                className="in-cell-field"
                name={[field.name, propName]}
                rules={[
                  {
                    required: true,
                  },
                ]}
                fieldKey={[field.fieldKey, propName]}
              >
                <Input min={1}
                       onKeyPress={(event) => {
                         if (!/[0-9]/.test(event.key)) {
                           event.preventDefault();
                         }
                       }}
                />
              </Form.Item>
            }
          },
          {
            key: "price",
            title: "Giá nhập",
            width: "15%",
            render: (_, field) => {
              const propName = "price";
              // const { age: value } = form.getFieldValue([
              //   prefix,
              //   field.name
              // ]);

              return <Form.Item
                {...field}
                label={'Giá nhập'}
                className="in-cell-field"
                name={[field.name, propName]}
                rules={[
                  {
                    required: true,
                  },
                ]}
                fieldKey={[field.fieldKey, propName]}
              >
                <Input min={0}
                       onKeyPress={(event) => {
                         if (!/[0-9]/.test(event.key)) {
                           event.preventDefault();
                         }
                       }}
                />
              </Form.Item>
            }
          },
          {
            key: "yearPublisher",
            title: "Ngày xuất bản",
            width: "20%",
            render: (_, field) => {
              const propName = "yearPublisher";
              // const { age: value } = form.getFieldValue([
              //   prefix,
              //   field.name
              // ]);

              return <Form.Item
                {...field}
                label={'Ngày xuất bản'}
                className="in-cell-field"
                name={[field.name, propName]}
                rules={[
                  {
                    required: true,
                  },
                ]}
                fieldKey={[field.fieldKey, propName]}
              >
                <CustomDatePicker type={'date'}
                                  format={'DD-MM-YYYY'}
                                  submitFormat
                  // formatter={(x) => moment(x).format('DD-MM-YYYY')}
                                  showTime={false}/>
              </Form.Item>
            }
          }
        ];

        // if (operatable) {
        //   columns.push({
        //     key: "operation",
        //     title: "Operation",
        //     width: 200,
        //     render: (_, field) => {
        //       const { _editing } = form.getFieldValue([prefix, field.name]);
        //       return _editing ? (
        //         <Form.Item
        //           {...field}
        //           className="in-cell-field"
        //           name={[field.name, "_editing"]}
        //           fieldKey={[field.fieldKey, "_editing"]}
        //           rules={[
        //             {
        //               validator: (_, value) => {
        //                 if (value === true) {
        //                   return Promise.reject(new Error("check it!"));
        //                 }
        //                 return Promise.resolve();
        //               }
        //             }
        //           ]}
        //         >
        //           <FieldUpdater>
        //             {({ onChange }) => (
        //               <Space>
        //                 <Button
        //                   onClick={async () => {
        //                     try {
        //                       await form.validateFields(
        //                         propNames.map(prop => [
        //                           prefix,
        //                           field.name,
        //                           prop
        //                         ])
        //                       );
        //                       onChange(false);
        //                       forceUpdateTable();
        //                     } catch {}
        //                   }}
        //                 >
        //                   Save
        //                 </Button>
        //                 <Button onClick={() => remove(field.name)}>
        //                   Cancel
        //                 </Button>
        //               </Space>
        //             )}
        //           </FieldUpdater>
        //         </Form.Item>
        //       ) : (
        //         <Button onClick={() => remove(field.name)}>remove</Button>
        //       );
        //     }
        //   });
        // }
        return (
          <>
            <Table dataSource={fields} pagination={false} columns={columns}/>
            <Button
              type="dashed"
              block
              style={{margin: "16px 0"}}
              onClick={append}
            >
              <PlusOutlined/> Thêm dữ liệu
            </Button>
          </>
        );
      }}
    </Form.List>
  );
};

export default ImportBookTableComponent;
