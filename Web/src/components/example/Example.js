import React from "react";
import { connect } from "react-redux";
import PropTypes from "prop-types";

class Example extends React.Component {
  constructor(props) {
    super(props);
    console.log(this.props);
  }
  render() {
    return (
      <div>
        <h1>I am in example component</h1>
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
