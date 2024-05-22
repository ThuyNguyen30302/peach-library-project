import React, {forwardRef, useImperativeHandle} from 'react';
import {DatePicker, TimePicker} from "antd";

const { RangePicker } = DatePicker;

const CustomDatePicker = forwardRef((props, ref) => {
    const {
        type,
        defaultValue,
        value,
        placeholder,
        minDate,
        maxDate,
        allowClear = true,
        autoFocus,
        className,
        disabled = false,
        disabledDate,
        disabledTime,
        format = "DD/MM/YYYY HH:mm",
        showTime = {
            format: 'HH:mm',
        },
        order,
        inputReadOnly,
        needConfirm,
        size = 'middle',
        style,
        variant = 'outlined',
        placement = 'bottomLeft',
        renderExtraFooter,
        onOk,
        onPanelChange,
        multiple,
        onChange
    } = props;


    useImperativeHandle(ref, () => ({}));

    const renderComponent = () => {
        switch (type) {
            case 'date':
                <DatePicker showTime={false} {...props} />
                break;
            case 'dateTime':
                <DatePicker {...props} />
                break;
            case 'month':
                <DatePicker picker={'month'} {...props} />
                break;
            case 'year':
                <DatePicker picker={'year'} {...props} />
                break;
            case 'quarter':
                <DatePicker picker={'quater'} {...props} />
                break;
            case 'time':
                <TimePicker {...props} />
                break;
            case 'week':
                <DatePicker picker={'week'} {...props} />
                break;
            case 'dateRange':
                <RangePicker />
                break;
            case 'monthRange':
                break;
            case 'yearRange':
                break;
            case 'timeRange':
                break;
            case 'selectDate':
                break;
            case 'selectDateRange':
                break;
            default:
                break;
        }
        ;
    };

    return (<div>

    </div>);
});

export default CustomDatePicker;