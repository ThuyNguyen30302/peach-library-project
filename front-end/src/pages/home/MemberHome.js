import React, {useEffect} from 'react';
import {useRequest} from "../../custom-hook/useRequest";
import useMergeState from "../../custom-hook/useMergeState";
import {MEMBER_COMBO_OPTION_API} from "../member/api/MemberApi";
import {BOOK_COPY_INDEX_API, BORROWED_BOOK_COPIES_API} from "../import-book/api/ImportBookApi";
import {CHECK_OUT_INDEX_API} from "../borrow/api/BorrowApi";
import _ from "lodash";
import "./homeStyle.scss";

const MemberHome = () => {
  const { get } = useRequest();
  const [state, setState] = useMergeState({
    amountMember: 0,
    amountBook: 0,
    amountBorrowedBook: 0,
    amountOverdue: 0,
    loading: true
  });
  const defaultColDef = {};

  useEffect(() => {
    fetchData();
  }, []);

  const fetchData = async () => {
    Promise.all([
      get(MEMBER_COMBO_OPTION_API),
      get(BOOK_COPY_INDEX_API),
      get(BORROWED_BOOK_COPIES_API),
      get(CHECK_OUT_INDEX_API + "/overdue"),
    ]).then(([resMember, resBook, resBorrowedBook, resOverdue]) => {
      if (resMember?.success && resBook?.success && resBorrowedBook?.success && resOverdue?.success) {
        const responseMember = resMember?.data;
        const responseBook = resBook?.data;
        const responseBorrowedBook = resBorrowedBook?.data;
        const responseOverdue = resOverdue?.data;
        if (responseMember && responseBook && responseBorrowedBook && responseOverdue) {
          setState({
            amountMember: _.size(responseMember),
            amountBook: _.size(responseBook),
            amountBorrowedBook: responseBorrowedBook,
            amountOverdue: _.size(responseOverdue),
            loading: false
          });
        }
      }
    });
  };

  const renderWidget = (number, label, color) => {
    return <div className={'home-widget col-span-1'} style={{backgroundColor: color}}>
      <div className={"number"} style={{textAlign: 'center'}}>{number}</div>
      <div className={"text"} style={{textAlign: 'center'}}>{label}</div>
    </div>;
  };
  return (
    <div className={"grid grid-cols-4 gap-4"}>
      {renderWidget(state.amountMember, "Số lượng sách đã từng mượn", '#FFE9D0')}
      <div></div>
      <div></div>
      <div></div>
      {renderWidget(state.amountOverdue, "Quá hạn", '#FFAAAA')}
    </div>
  );
};

export default MemberHome;