import React from 'react';
import {Redirect, Route, Switch, useHistory} from 'react-router-dom';
import {useSelector} from "react-redux";

const AppSwitch = () => {
    const history = useHistory();
    const {authData} = useSelector((stateRedux) => ({
        authData: stateRedux?.root?.get('authData'),
    }));
    const {
        login,
    } = useRequest();
    return (
        <div>
            
        </div>
    );
};

export default AppSwitch;