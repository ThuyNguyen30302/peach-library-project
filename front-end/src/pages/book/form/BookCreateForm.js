import React, {useRef} from 'react';
import {Form, Input, Select} from "antd";
import BaseForm from "../../../common/core/Form/BaseForm";
import _ from "lodash";

const BookCreateForm = (props) => {
  const formRef = useRef(null);

  const beforeSave = (data) => {
    const authors = _.get(data, 'authors');
    const type = _.get(data, 'type');
    const bookAuthorMappings = _.map(authors, x => ({authorId: x}));
    _.set(data, 'bookAuthorMappings', bookAuthorMappings);
    _.set(data, 'type', _.join(type, ','));

    return data;
  };

  const renderBody = () => {
    return <div className="grid grid-cols-2 gap-x-4">
      <Form.Item
        name="title"
        label="Tên"
        rules={[{
          required: true,
        }]}
        className={'col-span-2'}
      >
        <Input />
      </Form.Item>
      <Form.Item
        name="type"
        label="Thể loại sách"
        rules={[{
          required: true,
        }]}
        className={'col-span-2'}
      >
        <Select
          mode="multiple"
          maxTagCount={5}
          options={props.comboOptionBookType} />
      </Form.Item>
      <Form.Item
        name="authors"
        label="Tác giả"
        rules={[{
          required: true,
        }]}
        className={'col-span-2'}
      >
        <Select
          mode="multiple"
          maxTagCount={5}
          options={props.comboOptionAuthor} />
      </Form.Item>
    </div>
  };

  return (
    <div>
      <BaseForm
        ref={formRef}
        apiSave={props?.apiSave}
        reloadData={props.reloadData}
        beforeSave={beforeSave}
        onClose={() => props.onClose()}
      >
        {renderBody()}
      </BaseForm>
    </div>
  );
};

export default BookCreateForm;