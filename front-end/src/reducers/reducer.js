import * as Constant from "../constant/constant";
import _ from "lodash";
import moment from "moment";
import Immutable from 'immutable';

const storedAuthData = JSON.parse(sessionStorage.getItem('authData')) || {};

const initialState = Immutable.Map({
    isAuthenticated: !!storedAuthData && Object.keys(storedAuthData).length > 0, // Kiểm tra nếu có authData thì isAuthenticated là true
    authData: storedAuthData,
});

const rootReducer = (state = initialState, action) => {
    switch (action.type) {
        case Constant.LOG_OUT_SUCCESSFUL:
            return state.merge({
                isAuthenticated: false,
                authData: {},
            });
        case Constant.LOG_IN_SUCCESSFUL:
            return state.merge({
                isAuthenticated: true,
                authData: action.authData,
            });

        default:
            return state;
    }
};

export default rootReducer;