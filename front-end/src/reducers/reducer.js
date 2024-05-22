import * as Constant from "../constant/constant";
import _ from "lodash";
import moment from "moment";
import Immutable from 'immutable';

const initialState = Immutable.Map({
    isAuthenticated: false,
    rights: [],
    authData: {},
    menus: [],
    routes: [],
    sideMenu: [],
    configFilterGlobal: {
        show: false,

    },
    valueFilterGlobal: {
        year: localStorage.getItem('expired') && moment(localStorage.getItem('expired')) < moment() ? parseInt(localStorage.getItem('year') ?? '') : new Date().getFullYear()
    },
});

const rootReducer = (state = initialState, action) => {
    switch (action.type) {
        case Constant.ROUTE_CHANGED:
            return state;
        case Constant.LOG_OUT_SUCCESSFUL:
            return state.merge({
                isAuthenticated: false,
                authData: {},
            });
        case Constant.MENU_LAYOUT:
            return state.merge({
                menus: action.menu,
            });
        case Constant.SET_RIGHT:
            return state.merge({
                rights: action.payload,
            });
        case Constant.ROUTES_LAYOUT:
            return state.merge({
                routes: action.routes,
            });
        case Constant.LOG_IN_SUCCESSFUL:
            return state.merge({
                isAuthenticated: true,
                authData: action.authData,
            });
        case Constant.CHANGE_SIDEMENU:
            return state.merge({
                sideMenu: action.menu,
            });
        case Constant.GLOBAL_FILTER:
            const objCfg = {
                configFilterGlobal: action.config,
            };
            if (!action.config.show) {
                objCfg.valueFilterGlobal = {
                    year: localStorage.getItem('expired') && moment(localStorage.getItem('expired')) < moment() ? parseInt(localStorage.getItem('year') ?? '') : new Date().getFullYear()
                };
            }
            return state.merge(objCfg);

        case Constant.SET_VALUE_GLOBAL_FILTER:
            const tempState = _.get(state.toJS(), 'valueFilterGlobal');
            const diff = Object.keys(action.value).reduce((diff, key) => {
                if (tempState[key] === action.value[key]) return diff;
                return {
                    ...diff,
                    [key]: action.value[key]
                };
            }, {});
            if (!_.isEmpty(diff)) {
                const newState = Object.assign({...tempState}, action.value);
                if (newState.year) {
                    newState.year = parseInt(newState.year.toString());
                }
                return state.merge({
                    valueFilterGlobal: newState,
                });
            }
            return state;

        default:
            return state;
    }
};

export default rootReducer;