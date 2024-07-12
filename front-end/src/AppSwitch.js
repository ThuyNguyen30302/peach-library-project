import React from 'react';
import {Routes, Route, useNavigate, Navigate} from 'react-router-dom';
import {useSelector} from "react-redux";
import {useRequest} from "./custom-hook/useRequest";
import MainPage from "./pages/MainPage";
import LoginPage from "./pages/logIn/LoginPage";
import Loading from "./component/Loading";
import _ from "lodash";

const AppSwitch = () => {
  const navigate = useNavigate();
  const {authData} = useSelector((stateRedux) => ({
    authData: stateRedux?.root?.get('authData'),
  }));
  const {
    login,
  } = useRequest();

  const renderLoginPage = () => {
    return <>
      <Route path="*" element={<Navigate to="/login"/>}/>
      <Route path='/login' element={
        <LoginPage
          onSubmit={(form, values) => {
            const returnUrl = new URLSearchParams(window.location.search).get('returnUrl') || '/';
            login(form, values, () => navigate(returnUrl));
          }}
        />
      }/>
    </>;
  }

  return (
    <Routes>
      {_.isEmpty(authData) && renderLoginPage()}
      <Route path="/*" element={<MainPage/>}/>
    </Routes>
  );
};

export default AppSwitch;
