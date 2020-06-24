import React from "react";
import { connect } from "react-redux";
import PropTypes from "prop-types";
import { Button } from '@material-ui/core';

class Example extends React.Component {
  constructor(props) {
    super(props);
    console.log(this.props);
  }
  render() {
    return (
      <div>
        <h1>I am in example component</h1>
        <Button color="primary">Test of Material UI</Button>
      </div>
    );
  }
}
Example.propTypes = {
  example: PropTypes.object.isRequired,
};

function mapStateToProps(state) {
  return {
    example: state.example,
  };
}

export default connect(mapStateToProps)(Example);
