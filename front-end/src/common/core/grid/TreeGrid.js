import React, { forwardRef } from 'react';
import CommonGrid from './CommonGrid';

const TreeGrid = forwardRef((props, ref) => {
  return (
    <CommonGrid
      ref={ref}
      treeData
      getDataPath={props.treeDataPath}
      autoGroupColumnDef={{
        headerName: 'Group',
        cellRendererParams: { suppressCount: true },
        ...props.autoGroupColumnDef,
      }}
      {...props}
    />
  );
});

TreeGrid.displayName = 'TreeGrid';
export default TreeGrid;
