import React, {useContext, useEffect, useRef, useState} from 'react';
import BaseForm from "../../../common/core/Form/BaseForm";
import ImportBookTableComponent from "../component/ImportBookTableComponent";
import moment from "moment";
import _ from "lodash";


const itemsLayout = {
  labelCol: {flex: '0px'},
};


const ImportBookCreateForm = (props) => {
  const formRef = useRef(null);

  const [formInstance, setFormInstance] = useState(null);

  useEffect(() => {
    if (formRef.current) {
      setFormInstance(formRef.current);
    }
  }, []);

  const beforeSave = (data) => {
    _.forEach(_.get(data, 'importBooks'), (item) => {
      const yearPublisher = _.get(item, 'yearPublisher');
      _.set(item, 'yearPublisher', yearPublisher.format('YYYY-MM-DD'));
    })

    const res = [..._.get(data, 'importBooks')];
    return res;
  };

  const renderBody = () => {
    return <div>
      {formInstance && <ImportBookTableComponent name={'importBooks'}
                                                 combo={{
                                                   comboOptionBook: props.comboOptionBook,
                                                   comboOptionPublisher: props.comboOptionPublisher,
                                                 }}
                                                 form={formInstance}
                                                 operatable/>}
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
        {...itemsLayout}
        initialValues={{
          importBooks: [{amount: 1}]
        }}
      >
        {renderBody()}
      </BaseForm>
    </div>
  );
};

export default ImportBookCreateForm;