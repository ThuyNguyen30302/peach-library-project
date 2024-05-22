import {configureStore} from '@reduxjs/toolkit';
import {combineReducers} from 'redux';
import rootReducer from './reducers/reducer';

const reducer = combineReducers({
    // here we will be adding reducers
    root: rootReducer,
});

export const AppStore = configureStore({
    reducer,
});
