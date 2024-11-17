/* tslint:disable:no-unused-variable */
import { TestBed, async } from '@angular/core/testing';
import { DateTimeFormatPipe } from './DateTimeFormat.pipe';

describe('Pipe: DateTimeFormate', () => {
  it('create an instance', () => {
    const locale = 'pt-BR'; // Locale necessário, como 'en-US' ou 'pt-BR'
    const pipe = new DateTimeFormatPipe(locale);
    expect(pipe).toBeTruthy();
  });
});
