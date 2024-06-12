import React, {useRef} from 'react';
import {AgGridReact} from "ag-grid-react";

const BookListView = () => {
    const gridRef = useRef();

    return (
        <div>
            <AgGridReact ref={gridRef}  />
        </div>
    );
};

export default BookListView;