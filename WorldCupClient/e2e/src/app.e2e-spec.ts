import { browser, element, by, ElementFinder, ElementArrayFinder } from 'protractor';

const expectedH1 = 'Tour of Coaches';
const expectedTitle = `${expectedH1}`;
const targetCoach = { id: 15, name: 'Magneta' };
const targetCoachDashboardIndex = 2;
const nameSuffix = 'X';
const newCoachName = targetCoach.name + nameSuffix;

class Coach {
  constructor(public id: number, public name: string) {}

  // Factory methods

  // Coach from string formatted as '<id> <name>'.
  static fromString(s: string): Coach {
    return new Coach(
      +s.substring(0, s.indexOf(' ')),
      s.slice(s.indexOf(' ') + 1),
    );
  }

  // Coach from hero list <li> element.
  static async fromLi(li: ElementFinder): Promise<Coach> {
    const stringsFromA = await li.all(by.css('a')).getText();
    const strings = stringsFromA[0].split(' ');
    return { id: +strings[0], name: strings[1] };
  }

  // Coach id and name from the given detail element.
  static async fromDetail(detail: ElementFinder): Promise<Coach> {
    // Get hero id from the first <div>
    const id = await detail.all(by.css('div')).first().getText();
    // Get name from the h2
    const name = await detail.element(by.css('h2')).getText();
    return {
      id: +id.slice(id.indexOf(' ') + 1),
      name: name.substring(0, name.lastIndexOf(' '))
    };
  }
}

describe('Tutorial part 6', () => {

  beforeAll(() => browser.get(''));

  function getPageElts() {
    const navElts = element.all(by.css('app-root nav a'));

    return {
      navElts,

      appDashboardHref: navElts.get(0),
      appDashboard: element(by.css('app-root app-dashboard')),
      topCoaches: element.all(by.css('app-root app-dashboard > div a')),

      appCoachesHref: navElts.get(1),
      appCoaches: element(by.css('app-root app-heroes')),
      allCoaches: element.all(by.css('app-root app-heroes li')),
      selectedCoachSubview: element(by.css('app-root app-heroes > div:last-child')),

      heroDetail: element(by.css('app-root app-hero-detail > div')),

      searchBox: element(by.css('#search-box')),
      searchResults: element.all(by.css('.search-result li'))
    };
  }

  describe('Initial page', () => {

    it(`has title '${expectedTitle}'`, async () => {
      expect(await browser.getTitle()).toEqual(expectedTitle);
    });

    it(`has h1 '${expectedH1}'`, async () => {
      await expectHeading(1, expectedH1);
    });

    const expectedViewNames = ['Dashboard', 'Coaches'];
    it(`has views ${expectedViewNames}`, async () => {
      const viewNames = await getPageElts().navElts.map(el => el!.getText());
      expect(viewNames).toEqual(expectedViewNames);
    });

    it('has dashboard as the active view', async () => {
      const page = getPageElts();
      expect(await page.appDashboard.isPresent()).toBeTruthy();
    });

  });

  describe('Dashboard tests', () => {

    beforeAll(() => browser.get(''));

    it('has top heroes', async () => {
      const page = getPageElts();
      expect(await page.topCoaches.count()).toEqual(4);
    });

    it(`selects and routes to ${targetCoach.name} details`, dashboardSelectTargetCoach);

    it(`updates hero name (${newCoachName}) in details view`, updateCoachNameInDetailView);

    it(`cancels and shows ${targetCoach.name} in Dashboard`, async () => {
      await element(by.buttonText('go back')).click();
      await browser.waitForAngular(); // seems necessary to gets tests to pass for toh-pt6

      const targetCoachElt = getPageElts().topCoaches.get(targetCoachDashboardIndex);
      expect(await targetCoachElt.getText()).toEqual(targetCoach.name);
    });

    it(`selects and routes to ${targetCoach.name} details`, dashboardSelectTargetCoach);

    it(`updates hero name (${newCoachName}) in details view`, updateCoachNameInDetailView);

    it(`saves and shows ${newCoachName} in Dashboard`, async () => {
      await element(by.buttonText('save')).click();
      await browser.waitForAngular(); // seems necessary to gets tests to pass for toh-pt6

      const targetCoachElt = getPageElts().topCoaches.get(targetCoachDashboardIndex);
      expect(await targetCoachElt.getText()).toEqual(newCoachName);
    });

  });

  describe('Coaches tests', () => {

    beforeAll(() => browser.get(''));

    it('can switch to Coaches view', async () => {
      await getPageElts().appCoachesHref.click();
      const page = getPageElts();
      expect(await page.appCoaches.isPresent()).toBeTruthy();
      expect(await page.allCoaches.count()).toEqual(9, 'number of heroes');
    });

    it('can route to hero details', async () => {
      await getCoachLiEltById(targetCoach.id).click();

      const page = getPageElts();
      expect(await page.heroDetail.isPresent()).toBeTruthy('shows hero detail');
      const hero = await Coach.fromDetail(page.heroDetail);
      expect(hero.id).toEqual(targetCoach.id);
      expect(hero.name).toEqual(targetCoach.name.toUpperCase());
    });

    it(`updates hero name (${newCoachName}) in details view`, updateCoachNameInDetailView);

    it(`shows ${newCoachName} in Coaches list`, async () => {
      await element(by.buttonText('save')).click();
      await browser.waitForAngular();
      const expectedText = `${targetCoach.id} ${newCoachName}`;
      expect(await getCoachAEltById(targetCoach.id).getText()).toEqual(expectedText);
    });

    it(`deletes ${newCoachName} from Coaches list`, async () => {
      const heroesBefore = await toCoachArray(getPageElts().allCoaches);
      const li = getCoachLiEltById(targetCoach.id);
      await li.element(by.buttonText('x')).click();

      const page = getPageElts();
      expect(await page.appCoaches.isPresent()).toBeTruthy();
      expect(await page.allCoaches.count()).toEqual(8, 'number of heroes');
      const heroesAfter = await toCoachArray(page.allCoaches);
      // console.log(await Coach.fromLi(page.allCoaches[0]));
      const expectedCoaches =  heroesBefore.filter(h => h.name !== newCoachName);
      expect(heroesAfter).toEqual(expectedCoaches);
      // expect(page.selectedCoachSubview.isPresent()).toBeFalsy();
    });

    it(`adds back ${targetCoach.name}`, async () => {
      const addedCoachName = 'Alice';
      const heroesBefore = await toCoachArray(getPageElts().allCoaches);
      const numCoaches = heroesBefore.length;

      await element(by.css('input')).sendKeys(addedCoachName);
      await element(by.buttonText('Add hero')).click();

      const page = getPageElts();
      const heroesAfter = await toCoachArray(page.allCoaches);
      expect(heroesAfter.length).toEqual(numCoaches + 1, 'number of heroes');

      expect(heroesAfter.slice(0, numCoaches)).toEqual(heroesBefore, 'Old heroes are still there');

      const maxId = heroesBefore[heroesBefore.length - 1].id;
      expect(heroesAfter[numCoaches]).toEqual({id: maxId + 1, name: addedCoachName});
    });

    it('displays correctly styled buttons', async () => {
      const buttons = await element.all(by.buttonText('x'));

      for (const button of buttons) {
        // Inherited styles from styles.css
        expect(await button.getCssValue('font-family')).toBe('Arial, Helvetica, sans-serif');
        expect(await button.getCssValue('border')).toContain('none');
        expect(await button.getCssValue('padding')).toBe('1px 10px 3px');
        expect(await button.getCssValue('border-radius')).toBe('4px');
        // Styles defined in heroes.component.css
        expect(await button.getCssValue('left')).toBe('210px');
        expect(await button.getCssValue('top')).toBe('5px');
      }

      const addButton = element(by.buttonText('Add hero'));
      // Inherited styles from styles.css
      expect(await addButton.getCssValue('font-family')).toBe('Arial, Helvetica, sans-serif');
      expect(await addButton.getCssValue('border')).toContain('none');
      expect(await addButton.getCssValue('padding')).toBe('8px 24px');
      expect(await addButton.getCssValue('border-radius')).toBe('4px');
    });

  });

  describe('Progressive hero search', () => {

    beforeAll(() => browser.get(''));

    it(`searches for 'Ma'`, async () => {
      await getPageElts().searchBox.sendKeys('Ma');
      await browser.sleep(1000);

      expect(await getPageElts().searchResults.count()).toBe(4);
    });

    it(`continues search with 'g'`, async () => {
      await getPageElts().searchBox.sendKeys('g');
      await browser.sleep(1000);
      expect(await getPageElts().searchResults.count()).toBe(2);
    });

    it(`continues search with 'n' and gets ${targetCoach.name}`, async () => {
      await getPageElts().searchBox.sendKeys('n');
      await browser.sleep(1000);
      const page = getPageElts();
      expect(await page.searchResults.count()).toBe(1);
      const hero = page.searchResults.get(0);
      expect(await hero.getText()).toEqual(targetCoach.name);
    });

    it(`navigates to ${targetCoach.name} details view`, async () => {
      const hero = getPageElts().searchResults.get(0);
      expect(await hero.getText()).toEqual(targetCoach.name);
      await hero.click();

      const page = getPageElts();
      expect(await page.heroDetail.isPresent()).toBeTruthy('shows hero detail');
      const hero2 = await Coach.fromDetail(page.heroDetail);
      expect(hero2.id).toEqual(targetCoach.id);
      expect(hero2.name).toEqual(targetCoach.name.toUpperCase());
    });
  });

  async function dashboardSelectTargetCoach() {
    const targetCoachElt = getPageElts().topCoaches.get(targetCoachDashboardIndex);
    expect(await targetCoachElt.getText()).toEqual(targetCoach.name);
    await targetCoachElt.click();
    await browser.waitForAngular(); // seems necessary to gets tests to pass for toh-pt6

    const page = getPageElts();
    expect(await page.heroDetail.isPresent()).toBeTruthy('shows hero detail');
    const hero = await Coach.fromDetail(page.heroDetail);
    expect(hero.id).toEqual(targetCoach.id);
    expect(hero.name).toEqual(targetCoach.name.toUpperCase());
  }

  async function updateCoachNameInDetailView() {
    // Assumes that the current view is the hero details view.
    await addToCoachName(nameSuffix);

    const page = getPageElts();
    const hero = await Coach.fromDetail(page.heroDetail);
    expect(hero.id).toEqual(targetCoach.id);
    expect(hero.name).toEqual(newCoachName.toUpperCase());
  }

});

async function addToCoachName(text: string): Promise<void> {
  const input = element(by.css('input'));
  await input.sendKeys(text);
}

async function expectHeading(hLevel: number, expectedText: string): Promise<void> {
  const hTag = `h${hLevel}`;
  const hText = await element(by.css(hTag)).getText();
  expect(hText).toEqual(expectedText, hTag);
}

function getCoachAEltById(id: number): ElementFinder {
  const spanForId = element(by.cssContainingText('li span.badge', id.toString()));
  return spanForId.element(by.xpath('..'));
}

function getCoachLiEltById(id: number): ElementFinder {
  const spanForId = element(by.cssContainingText('li span.badge', id.toString()));
  return spanForId.element(by.xpath('../..'));
}

async function toCoachArray(allCoaches: ElementArrayFinder): Promise<Coach[]> {
  return allCoaches.map(hero => Coach.fromLi(hero!));
}
