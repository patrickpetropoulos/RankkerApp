import React from "react";
import App from "./App";
import { shallow } from "enzyme";

describe("App", () => {
  it("redner app without crashing", () => {
    const appWrapper = shallow(<App />);
  });

  it("finds title in App component", () => {
    const appWrapper = shallow(<App />);
    const h1Found = appWrapper.find("h1");

    expect(h1Found).toHaveLength(1);
  });
});
