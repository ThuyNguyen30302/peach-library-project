import React, {useEffect, useState} from 'react';
import {IFilterConfig, ITypeFilter} from './FilterGlobalComponent';
import moment from 'moment';
const ItemFilterComponent = (props) => {
    const [loading, setLoading] = useState(true);

    const {filterConfig, year, style, value, options, type, setOptions} = props;
    const delay = 1;

    useEffect(
        () => {
            setLoading(true);
            const timer1 = setTimeout(() => setLoading(false), delay * 1000);

            // this will clear Timeout
            // when component unmount like in willComponentUnmount
            // and show will not change to true
            return () => {
                clearTimeout(timer1);
            };
        },
        // useEffect will run only one time with empty []
        // if you pass a value to array,
        // like this - [data]
        // than clearTimeout will run every time
        // this value changes (useEffect re-run)
        []
    );

    const onSetYear = (val, format) => {
        if (val && moment(val, format, true).isValid()) {
            const mm = moment(val, format);
            localStorage.setItem('year', mm.format('YYYY'));
            localStorage.setItem('expired', moment().format('YYYY-MM-DD HH:mm'));
        }
    };

    const onChange = (val) => {
        props.onChangeDefault(val);
        props.callbackOnChange?.(val);
    };


    const getByType = () => {
        switch (type) {
            case 'combobox':
                return <div style={{minWidth: 150}}>
                    <Select
                        options={options}
                        defaultValue={value}
                        onChange={onChange}
                        isClearable={false}
                        style={Object.assign({width: 150}, style)}
                    /></div>;
            case 'dateSelectYear':
                const date = filterConfig?.toDate ? moment(filterConfig?.toDate) : null;
                return <div className={'flex items-center'}>
                    <div style={{marginRight: 5}}>
                        {`Ngày ${date ? date.format('DD') : '__'}/${date ? date.format('MM') : '__'}/`}
                    </div>
                    <div>
                        <DatePicker
                            type={'year'}
                            icon={<Icon type={'caret-down'}/>}
                            defaultValue={year}
                            value={year}
                            onChange={(val) => {
                                onChange(val);
                                onSetYear(val, 'YYYY');
                            }}
                            isClearable={false}
                            style={Object.assign({width: 80}, style)}
                        />
                    </div>
                </div>;
            case 'weekDateSelectYear':
                const toDate = moment(filterConfig?.toDate);
                return <div className={'flex items-center'}>
                    <div style={{marginRight: 5}}>
                        {`Tuần ${filterConfig?.week}  Ngày ${toDate?.format('DD')}/${toDate?.format('MM')}/`}
                    </div>
                    <div>
                        <IDDatePicker type={'year'}
                                      icon={<Icon type={'caret-down'}/>}
                                      defaultValue={moment(value)}
                                      value={moment(value)}
                                      onChange={(val) => {
                                          onChange(val);
                                          onSetYear(val, 'YYYY');
                                      }}
                                      isClearable={false}
                                      style={Object.assign({width: 80}, style)}
                        />
                    </div>
                </div>;
            case 'monthYearSelectYear':
                return <div className={'flex items-center'}>
                    <div style={{marginRight: 5}}>
                        {`Tháng ${filterConfig?.month ? filterConfig.month : '__'}/`}
                    </div>
                    <div>
                        <IDDatePicker type={'year'}
                                      icon={<Icon type={'caret-down'}/>}
                                      defaultValue={(value)}
                                      value={value}
                                      onChange={(val) => {
                                          onChange(val);
                                          onSetYear(val, 'YYYY');
                                      }}
                                      isClearable={false}
                                      style={Object.assign({width: 100}, style)}
                        />
                    </div>
                </div>;
            case 'selectSingleDate':
                const reportDate = moment(filterConfig?.date);
                return <IDDatePicker type={'date'}
                                     icon={<Icon type={'caret-down'}/>}
                    // defaultValue={reportDate || moment().format('YYYY/MM/DD')}
                                     value={value}
                                     onChange={(val) => {
                                         onChange(val);
                                         onSetYear(val, 'YYYY-MM-DD');
                                     }}
                                     isClearable={false}
                                     placeholder={''}
                                     style={Object.assign({width: 120}, style)}
                />;
            case 'selectWeek':
                const optWeek[] = [];
                if (filterConfig?.maxWeek) {
                    for (let i = 1; i <= filterConfig?.maxWeek; i++) {
                        optWeek.push({
                            label: i,
                            value: i
                        });
                    }
                }
                return <div className={'flex items-center'}>
                    <div style={{marginRight: 5}}>Tuần</div>
                    <Select
                        icon={<Icon type={'caret-down'}/>}
                        options={optWeek}
                        defaultValue={filterConfig?.week}
                        value={value}
                        onChange={onChange}
                        isClearable={false}
                        style={Object.assign({width: 100}, style)}
                    /></div>;
            case 'selectQuarter':

                return <IDDatePicker
                    type={'quarter'}
                    icon={<Icon type={'caret-down'}/>}
                    onChange={(val) => {
                        onChange(val);
                        onSetYear(val, 'YYYY-MM-DD');
                    }}
                    value={value ? moment(value) : null}
                    onlyQuarter={false}
                    allowClear={false}
                    placeholder={''}
                    format={'[QUÝ] Q/YYYY'}
                    style={{width: 120}}
                />;
            case 'selectYear':
                return <div className={'flex items-center'}>
                    <div style={{marginRight: 5}}>Năm</div>
                    <IDDatePicker icon={<Icon type={'caret-down'}/>} type={'year'}
                                  value={moment(value, 'YYYY')}
                                  defaultValue={moment(value, 'YYYY')}
                                  onChange={(val) => {
                                      onChange(val);
                                      onSetYear(val, 'YYYY');
                                  }}

                                  isClearable={false}
                                  style={Object.assign({width: 80}, style)}
                    />
                </div>;
            case 'selectSingleMonth':
                const optMonth[] = [];
                for (let i = 1; i <= 12; i++) {
                    optMonth.push({
                        label: i,
                        value: i
                    });
                }
                return <div className={'flex items-center'}>
                    <div style={{marginRight: 5}}>Tháng</div>
                    <Select options={optMonth}
                            isClearable={false}
                            defaultValue={filterConfig?.month}
                            value={filterConfig?.month}
                            style={Object.assign({width: 70}, style)} onChange={onChange}/>
                </div>;
            case 'displaySingleMonth':
                return <div className={'flex items-center'}>
                    <div style={{marginRight: 2}}>Tháng {filterConfig?.month ?? '__'}/</div>
                </div>;
            case 'displayDate':
                return <div className={'flex items-center'}>
                    <div
                        style={{marginRight: 2}}>Ngày {filterConfig?.toDate ? moment(filterConfig?.toDate).format('DD/MM') : '__/__'}/
                    </div>
                </div>;
            case 'displayWeek':
                return <div className={'flex items-center'}>
                    <div style={{marginRight: 2}}>Tuần {filterConfig?.week ?? '__'}</div>
                </div>;
            case 'selectPeriod':
                const opt[] = [];
                if (filterConfig?.maxPeriod) {
                    for (let i = 1; i <= filterConfig?.maxPeriod; i++) {
                        opt.push({
                            label: i,
                            value: i
                        });
                    }
                }
                return <div className={'flex items-center'}>
                    <div style={{marginRight: 5}} className={''}>Kỳ</div>
                    <Select options={opt}
                            isClearable={false}
                            defaultValue={filterConfig?.period}
                            notFoundContent={<></>}
                            value={value}
                            placeholder={'...'}
                            style={Object.assign({width: 70}, style)} onChange={onChange}/>
                    <div style={{marginLeft: 5}}>
                        {`(${filterConfig?.fromDate ? moment(filterConfig?.fromDate, 'YYYY-MM-DD').format('DD/MM') : '__/__'} 
                        - ${filterConfig?.fromDate ? moment(filterConfig?.toDate, 'YYYY-MM-DD').format('DD/MM') : '__/__'})`}
                    </div>
                </div>;
            case 'selectMonth':
                return <IDDatePicker type={'month'}
                                     icon={<Icon type={'caret-down'}/>}
                                     value={value ? moment(value, 'MM/YYYY').format('MM/YYYY') : moment(year, 'YYYY')}
                                     onChange={(val) => {
                                         onChange(val);
                                         onSetYear(val, 'MM/YYYY');
                                     }}
                                     isClearable={false}
                                     displayFormat={'MMMM'}
                                     style={Object.assign({width: 120}, style)}
                />;
            default:
                return <></>;
        }
    };

    if (loading) {
        const obj = {
            combobox: 150,
            dateSelectYear: 150,
            weekDateSelectYear: 270,
            monthYearSelectYear: 200,
            selectSingleDate: 120,
            singleDateSelectYear: 150,
            selectQuarter: 120,
            selectYear: 110,
            selectPeriod: 180,
            selectMonth: 90,
            selectWeek: 100,
            selectSingleMonth: 120,
            displaySingleMonth: 120,
            displayDate: 120,
            displayWeek: 120,
        };
        const styleMerge = Object.assign({
            width: obj[type],
            minWidth: obj[type],
            borderRadius: 3
        }, style);
        return <div className={'flex items-center '}>
            <Skeleton.Input style={styleMerge} active/>
            <div style={{opacity: 0, width: 0}}>
                {getByType()}
            </div>
        </div>;
    }
    return getByType();
};

export default ItemFilterComponent;