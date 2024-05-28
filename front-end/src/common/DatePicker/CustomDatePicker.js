import React, { forwardRef, useImperativeHandle, useRef, useState } from 'react';
import { DatePicker, TimePicker } from "antd";

const { RangePicker } = DatePicker;

const CustomDatePicker = forwardRef((props, ref) => {
    const {
        type,
        defaultValue,
        value,
        placeholder,
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
        onChange,
        ...rest
    } = props;

    const [minDate, setMinDate] = useState(props?.minDate);
    const [maxDate, setMaxDate] = useState(props?.maxDate);
    const refDate = useRef();

    useImperativeHandle(ref, () => ({
        refDate,
        setMaxDate,
        setMinDate
    }));

    const handleDisabledDate = (current) => {
        if (minDate && current < minDate) {
            return true;
        }
        if (maxDate && current > maxDate) {
            return true;
        }
        return false;
    };

    const renderComponent = () => {
        const commonProps = {
            ref: refDate,
            disabledDate: handleDisabledDate,
            format,
            showTime,
            allowClear,
            autoFocus,
            className,
            disabled,
            size,
            style,
            renderExtraFooter,
            onOk,
            onPanelChange,
            onChange,
            ...rest
        };

        switch (type) {
            case 'date':
                return <DatePicker {...commonProps} />;
            case 'dateTime':
                return <DatePicker showTime {...commonProps} />;
            case 'month':
                return <DatePicker picker="month" {...commonProps} />;
            case 'year':
                return <DatePicker picker="year" {...commonProps} />;
            case 'quarter':
                return <DatePicker picker="quarter" {...commonProps} />;
            case 'week':
                return <DatePicker picker="week" {...commonProps} />;
            case 'time':
                return <TimePicker {...commonProps} />;
            case 'dateRange':
                return <RangePicker {...commonProps} />;
            case 'dateTimeRange':
                return <RangePicker showTime {...commonProps} />;
            case 'monthRange':
                return <RangePicker picker="month" {...commonProps} />;
            case 'yearRange':
                return <RangePicker picker="year" {...commonProps} />;
            case 'weekRange':
                return <RangePicker picker="week" {...commonProps} />;
            case 'quarterRange':
                return <RangePicker picker="quarter" {...commonProps} />;
            case 'selectDate':
                return <DatePicker {...commonProps} />;
            default:
                return null;
        }
    };

    return (
        <div>
            {renderComponent()}
        </div>
    );
});

export default CustomDatePicker;
