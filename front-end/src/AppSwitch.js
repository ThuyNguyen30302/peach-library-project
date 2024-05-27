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

    return (
          <>
              {/*{_.isEmpty(authData) && (*/}
              {/*  <Route path='/login' element={*/}
              {/*      <LoginPage*/}
              {/*        loading={<Loading />}*/}
              {/*        onSubmit={(form, model) => {*/}
              {/*            const returnUrl = new URLSearchParams(window.location.search).get('returnUrl') || '/home';*/}
              {/*            login(form, model, () => navigate(returnUrl));*/}
              {/*        }}*/}
              {/*      />*/}
              {/*  } />*/}
              {/*)}*/}
              <MainPage />
          </>
    );
};

export default AppSwitch;
