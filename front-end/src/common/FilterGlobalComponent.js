const FilterGlobalComponent = () => {
    const {configFilter, valueFilter} = useSelector((stateRedux) => ({
        configFilter: stateRedux?.root?.get('configFilterGlobal') as IFilterGlobal,
        valueFilter: stateRedux?.root?.get('valueFilterGlobal') as IValueFilterGlobal
    }));
    const onChangeDefault = (key, val) => {
        const obj = {} as IValueFilterGlobal;
        obj[key] = val;
        if (obj[key] !== valueFilter[key]) {
            AppStore.dispatch(setValueGlobalFilter(obj));
        }
    };

    const renderElement = () => {
        return configFilter?.element?.map((item, index) => {
            return <div className={'item-filter item-filter-component'} key={item.type} style={{
                margin: 4
            }}>
                <ItemFilterComponent
                    {...item}
                    onChangeDefault={(val) => onChangeDefault(item.keyValue, val)}
                    value={valueFilter[item.keyValue] || item.value}
                    year={valueFilter.year}
                    filterConfig={configFilter?.filterConfig}
                />
            </div>;
        });
    };

    if (configFilter?.show) {
        return <div className={'filter-global'}>
            {renderElement()}
        </div>;
    }
    return (
        <></>
    );
};

export default FilterGlobalComponent;