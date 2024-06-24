import React from 'react';

const useMergeState = (initialState = {}) => {
  const [value, setValue] = React.useState(initialState);

  const mergeState = (newState) => {
    setValue((prevState) => ({
      ...prevState,
      ...newState instanceof Function ? newState(prevState) : newState,
    }));
  };

  return [value, mergeState];
};

export default useMergeState;