import ReactLoading from 'react-loading';

const Loading = (props) => {
  const {text} = props;
  return (
    <div className="full-screen d-flex align-items-center justify-content-center flex-column">
      <ReactLoading type="cylon" color="#0088fe" height={50} width={50}/>
      <p>{text || ''}</p>
    </div>
  );
};

export default Loading;