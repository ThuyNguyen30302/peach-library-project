import React, { forwardRef } from 'react';
import CommonGrid from "./CommonGrid";

const Grid = forwardRef((props, ref) => {
  return (
    <CommonGrid
      ref={ref}
      {...props}
    />
  );
});

Grid.displayName = 'Grid';
export default Grid;
