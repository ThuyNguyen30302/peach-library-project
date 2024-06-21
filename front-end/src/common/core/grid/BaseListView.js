import React, { useRef, useImperativeHandle, forwardRef } from 'react';
import Grid from "./Grid";
import TreeGrid from "./TreeGrid";

const BaseListView = forwardRef((props, ref) => {
  const gridRef = useRef(null);

  // const reloadData = () => {
  //   if (gridRef.current) {
  //     gridRef.current.reloadData();
  //   }
  // };

  // Forwarding setRowData method to parent ref
  useImperativeHandle(ref, () => ({
    setRowData: (data) => {
      if (gridRef.current) {
        gridRef.current.setRowData(data);
      }
    },
    // reloadData: reloadData
  }));

  const renderGrid = () => {
    return (
      <Grid
        ref={gridRef}
        columnDefs={props.columnDefs}
        defaultColDef={props.defaultColDef}
        rowData={props.rowData}
        formCRUD={props.formCRUD}
        buttonCRUD={props.buttonCRUD}
        rightConfig={props.rightConfig}
        // reloadData={reloadData}
        {...props.gridProps}
      />
    );
  };

  const renderTreeGrid = () => {
    return (
      <TreeGrid
        ref={gridRef}
        columnDefs={props.columnDefs}
        defaultColDef={props.defaultColDef}
        rowData={props.rowData}
        formCRUD={props.formCRUD}
        buttonCRUD={props.buttonCRUD}
        rightConfig={props.rightConfig}
        // reloadData={reloadData}
        treeDataPath={props.treeDataPath}
        autoGroupColumnDef={props.autoGroupColumnDef}
        {...props.gridProps}
      />
    );
  };

  return (
    <div style={{ height: '100%', width: '100%' }}>
      {/*{props.isGridDefault ? renderGrid() : renderTreeGrid()}*/}
      {renderGrid()}
    </div>
  );
});

export default BaseListView;
