import React, {forwardRef, useImperativeHandle, useRef} from 'react';
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
        multiple = false,
        allowClear = true,
        autoFocus,
        className,
        disabled = false,
        disabledDate,
        disabledTime,
        format = 'DD/MM/YYYY HH:mm',
        showTime = {
            format: 'HH:mm',
        },
        maxTagCount = 'responsive',
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
        onChange
    } = props;

    const refDate = useRef();


    useImperativeHandle(ref, () => ({
        refDate
    }));

    const renderComponent = () => {
        switch (type) {
            case 'date':
                <DatePicker ref={refDate} ref={refDate} showTime={false} {...props} />
                break;
            case 'dateTime':
                <DatePicker ref={refDate} {...props} />
                break;
            case 'month':
                <DatePicker ref={refDate} picker={'month'} {...props} />
                break;
            case 'year':
                <DatePicker ref={refDate} picker={'year'} {...props} />
                break;
            case 'quarter':
                <DatePicker ref={refDate} picker={'quater'} {...props} />
                break;
            case 'week':
                <DatePicker ref={refDate} picker={'week'} {...props} />
                break;
            case 'time':
                <TimePicker ref={refDate} {...props} />
                break;
            case 'dateRange':
                <RangePicker ref={refDate} showTime={false} {...props} />
                break;
            case 'dateTimeRange':
                <RangePicker ref={refDate} {...props} />
                break;
            case 'monthRange':
                return <RangePicker ref={refDate} picker={'month'} {...props} />
            case 'yearRange':
                return <RangePicker ref={refDate} picker={'year'} {...props} />
            case 'weekRange':
                return <RangePicker ref={refDate} picker={'week'} {...props} />
            case 'quarterRange':
                return <RangePicker ref={refDate} picker={'quater'} {...props} />
            case 'selectDate':
                return <DatePicker ref={refDate} multiple={true} {...props} />
            default:
                break;
        }
    };

    return (<div>
        {renderComponent()}
    </div>);
});

export default CustomDatePicker;