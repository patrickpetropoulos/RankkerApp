import { combineReducers } from "redux";
import example from "./exampleReducer";
//remaned since it is default export in file

const rootReducer = combineReducers({ example });

export default rootReducer;
