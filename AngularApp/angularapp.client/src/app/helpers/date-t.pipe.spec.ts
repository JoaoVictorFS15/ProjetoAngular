import { DateTPipe } from './date-t.pipe';

describe('DateTPipe', () => {
  it('create an instance', () => {
    const pipe = new DateTPipe("pt-br");
    expect(pipe).toBeTruthy();
  });
});
