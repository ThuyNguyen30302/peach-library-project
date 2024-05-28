import ReactLoading from 'react-loading';
import {Spin} from "antd";
import "../style/style-component.scss";

const Loading = (props) => {
  const {text} = props;
  return (
    <div className="loading-component">
        <Spin size="large" />
        <div className={'mt-4'}>{text || ''}</div>
    </div>
  );
};

export default Loading;